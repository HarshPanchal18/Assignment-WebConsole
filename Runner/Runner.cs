using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;

public class Runner {
    public Runner() { }

    public bool RunCsCode(string sourceCode) {
        char[] whitespace = [' ', '\t', '\r', '\n'];

        try {

            // Trimming whitespaces from the source code.
            string[] trimmedCode = sourceCode.Split(whitespace, StringSplitOptions.RemoveEmptyEntries);

            sourceCode = string.Join(" ", trimmedCode);

            // Setting up the compiler
            var provider = new CSharpCodeProvider();
            var parameters = new CompilerParameters {
                GenerateExecutable = false,
                GenerateInMemory = true,
            };

            // add a reference to following assemblies, necessary for the code to run.
            parameters.ReferencedAssemblies.Add("System.dll"); // for the core functionalities of .NET such as primitive types, collections
            parameters.ReferencedAssemblies.Add("System.Core.dll"); // to support advanced features like LINQ, lambda expressions

            // Compiling the source-code into an assembly
            CompilerResults results = provider.CompileAssemblyFromSource(parameters, sourceCode);

            if (results.Errors.Count > 0) { // Compilation error
                foreach (CompilerError error in results.Errors) {
                    Console.WriteLine($"Error ({error.ErrorNumber}): {error.ErrorText}");
                }
            } else {
                Assembly assembly = results.CompiledAssembly;
                Type programType = assembly.GetType("Program"); // ClassName of the source-code which contains Main()
                MethodInfo mainMethod = programType.GetMethod("Main"); // Provide entry point method name to start from

                // Invoke the Main method
                mainMethod.Invoke(
                    null, // Main is a static mwthod.
                    null // no arguments are needed. e.x., string[] args = { "arg1", "arg2" }; mainMethod.Invoke(null, new object[] { args });
                );
            }

            return true;

        } catch (Win32Exception ex) {
            Console.WriteLine("System error...");
            Console.WriteLine(ex.Message);
            return false;
        } catch (Exception ex) {
            Console.WriteLine("Unhandled Exception occurred...");
            Console.WriteLine(ex.Message);
            return false;
        }

    }

    public void RunCprogram(string sourceCode) {

        string sourceFile = "program.c";
        File.WriteAllText(sourceFile, sourceCode); // Write source code to a file

        // Compile C++ code
        Process compileProcess = new Process();
        compileProcess.StartInfo.FileName = "g++"; // You need to have g++ or any C++ compiler installed
        compileProcess.StartInfo.Arguments = $"{sourceFile} -o program.exe"; // Compile to executable
        compileProcess.StartInfo.RedirectStandardOutput = true;
        compileProcess.StartInfo.RedirectStandardError = true;
        compileProcess.StartInfo.UseShellExecute = false;
        compileProcess.StartInfo.CreateNoWindow = true;
        compileProcess.Start();

        string compileOutput = compileProcess.StandardOutput.ReadToEnd();
        string compileError = compileProcess.StandardError.ReadToEnd();
        compileProcess.WaitForExit();

        // Check for compilation errors
        if (!string.IsNullOrEmpty(compileError)) {
            Console.WriteLine("Compilation errors:");
            Console.WriteLine(compileError);
            return;
        }

        // Run the compiled program
        Process runProcess = new Process();
        runProcess.StartInfo.FileName = "./program.exe"; // Execute the compiled binary
        runProcess.StartInfo.RedirectStandardOutput = true;
        runProcess.StartInfo.RedirectStandardError = true;
        runProcess.StartInfo.UseShellExecute = false;
        runProcess.StartInfo.CreateNoWindow = true;
        runProcess.Start();

        string runOutput = runProcess.StandardOutput.ReadToEnd();
        string runtimeError = runProcess.StandardError.ReadToEnd();
        runProcess.WaitForExit();

        // Display the output or errors from running the program
        if (!string.IsNullOrEmpty(runtimeError)) {
            Console.WriteLine("Runtime errors:");
            Console.WriteLine(runtimeError);
        } else {
            Console.WriteLine("Program output:");
            Console.WriteLine(runOutput);
        }

    }

    public string RunCppProgram(string sourceCode) {
        string sourceFile = "program.cpp";
        File.WriteAllText(sourceFile, sourceCode); // Write source code to a file

        // Compile C++ code
        Process compileProcess = new Process();
        compileProcess.StartInfo.FileName = "g++"; // You need to have g++ or any C++ compiler installed
        compileProcess.StartInfo.Arguments = $"{sourceFile} -o program.exe"; // Compile to executable
        compileProcess.StartInfo.RedirectStandardOutput = true;
        compileProcess.StartInfo.RedirectStandardError = true;
        compileProcess.StartInfo.UseShellExecute = false;
        compileProcess.StartInfo.CreateNoWindow = true;
        compileProcess.Start();

        string compileOutput = compileProcess.StandardOutput.ReadToEnd();
        string compileError = compileProcess.StandardError.ReadToEnd();
        compileProcess.WaitForExit();

        // Check for compilation errors
        if (!string.IsNullOrEmpty(compileError)) {
            Console.WriteLine("Compilation errors:");
            Console.WriteLine(compileError);
            return compileError;
        }

        // Run the compiled program
        Process runProcess = new Process();
        runProcess.StartInfo.FileName = "./program.exe"; // Execute the compiled binary
        runProcess.StartInfo.RedirectStandardOutput = true;
        runProcess.StartInfo.RedirectStandardError = true;
        runProcess.StartInfo.UseShellExecute = false;
        runProcess.StartInfo.CreateNoWindow = true;
        runProcess.Start();

        string runOutput = runProcess.StandardOutput.ReadToEnd();
        string runtimeError = runProcess.StandardError.ReadToEnd();
        runProcess.WaitForExit();

        // Display the output or errors from running the program
        if (!string.IsNullOrEmpty(runtimeError)) {
            Console.WriteLine("Runtime errors:");
            Console.WriteLine(runtimeError);
            return runtimeError;
        } else {
            Console.WriteLine("Program output:");
            Console.WriteLine(runOutput);
            return runOutput;
        }
    }

    public void RunPythonProgram(string sourceCode) {

        string pythonFile = "Program.py";
        File.WriteAllText(pythonFile, sourceCode);

        // Run the Python interpreter
        Process pythonProcess = new Process();
        pythonProcess.StartInfo.FileName = "python";
        //pythonProcess.StartInfo.Arguments = $"-c \"{sourceCode}\"";
        pythonProcess.StartInfo.Arguments = $"{pythonFile}";
        pythonProcess.StartInfo.RedirectStandardOutput = true;
        pythonProcess.StartInfo.RedirectStandardError = true;
        pythonProcess.StartInfo.UseShellExecute = false;
        pythonProcess.StartInfo.CreateNoWindow = true;
        pythonProcess.Start();

        // Output and errors
        string output = pythonProcess.StandardOutput.ReadToEnd();
        string error = pythonProcess.StandardError.ReadToEnd();
        pythonProcess.WaitForExit();

        // Display output or errors
        if (!string.IsNullOrEmpty(error)) {
            Console.WriteLine("Python errors:");
            Console.WriteLine(error);
        } else {
            Console.WriteLine("Python output:");
            Console.WriteLine(output);
        }
    }

    public string RunJavaProgram(string sourceCode) {
        // Write source code to a temporary file
        string javaFile = "Program.java";
        File.WriteAllText(javaFile, sourceCode);

        // Compile the Java code using javac
        Process compileProcess = new Process();
        compileProcess.StartInfo.FileName = "javac";
        compileProcess.StartInfo.Arguments = javaFile;
        compileProcess.StartInfo.RedirectStandardOutput = true;
        compileProcess.StartInfo.RedirectStandardError = true;
        compileProcess.StartInfo.UseShellExecute = false;
        compileProcess.StartInfo.CreateNoWindow = true;
        compileProcess.Start();

        string compileOutput = compileProcess.StandardOutput.ReadToEnd();
        string compileError = compileProcess.StandardError.ReadToEnd();
        compileProcess.WaitForExit();

        // Check for compilation errors
        if (!string.IsNullOrEmpty(compileError)) {
            Console.WriteLine("Compilation errors:");
            Console.WriteLine(compileError);
            return compileError;
        }

        // Step 3: Run the compiled Java program using the java command
        Process runProcess = new Process();
        runProcess.StartInfo.FileName = "java"; // Ensure the Java runtime is installed
        runProcess.StartInfo.Arguments = "Program"; // Run the compiled Java class
        runProcess.StartInfo.RedirectStandardOutput = true;
        runProcess.StartInfo.RedirectStandardError = true;
        runProcess.StartInfo.UseShellExecute = false;
        runProcess.StartInfo.CreateNoWindow = true;
        runProcess.Start();

        string runOutput = runProcess.StandardOutput.ReadToEnd();
        string runError = runProcess.StandardError.ReadToEnd();
        runProcess.WaitForExit();

        // Display the output or errors
        if (!string.IsNullOrEmpty(runError)) {
            Console.WriteLine("Runtime errors:");
            Console.WriteLine(runError);
            return runError;
        } else {
            Console.WriteLine("Program output:");
            Console.WriteLine(runOutput);
            return runOutput;
        }
    }
}
