using System;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks.Dataflow;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using TestGeneratorLib;

namespace MPP4
{

    class Program
    {

        static async Task Main()
        {
            await Method1();
        }


        public static async Task Method1()
        {
            string path = @"C:\\Users\\Yana\\source\\repos\\MPP_4\\MPP4\\Files";
            string resultPath = @"C:\\Users\\Yana\\source\\repos\\MPP_4\\TestProject\\ResultTests";

            var classFiles = new List<string>();
            foreach (string Onefile in Directory.GetFiles(path, "*.cs"))
            {
                classFiles.Add(Onefile);
            }

            int maxFilesToLoad = 3;
            int maxExecuteTasks = 3;
            int maxFilesToWrite = 3;
            
            TestGenerator generator = new TestGenerator(classFiles, resultPath, maxFilesToLoad, maxExecuteTasks, maxFilesToWrite);
            await generator.Generate();

            Console.WriteLine("END");
        }
    }



}