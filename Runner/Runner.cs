using Microsoft.CodeAnalysis.Scripting;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using System.Diagnostics;
using Microsoft.CodeAnalysis;
using System.Reflection;
using System.CodeDom.Compiler;
using Microsoft.CSharp;

public class Runner {
    public Runner() { }

    public string RunCsCode(string sourceCode) {
        char[] whitespace = [' ', '\t', '\r', '\n'];

        try {

            // Redirecting Console output
            var stringWriter = new StringWriter();
            Console.SetOut(TextWriter.Null);

            var validAsm = AppDomain.CurrentDomain
                            .GetAssemblies()
                            .Where(a => !a.IsDynamic && !string.IsNullOrEmpty(a.Location))
                            .Select(a => MetadataReference.CreateFromFile(a.Location))
                            .ToList();

            var options = ScriptOptions.Default
                            .WithReferences(validAsm)
                            .WithImports("System", "System.Linq");

            // Running the script
            var result = CSharpScript.RunAsync(sourceCode, options).Result;

            // Capturing the output of Console.WriteLine
            var output = stringWriter.ToString();

            return string.IsNullOrEmpty(output) ? "NULL" : output;

            // return result?.ToString() ?? "No result";

        } catch (CompilationErrorException ex) {
            return "Compilation Error: " + string.Join(Environment.NewLine, ex.Diagnostics);
        } catch (Exception ex) {
            return "Execution Error: " + ex.Message;
        }
    }

    public string RunCprogram(string sourceCode) {

        string sourceFile = "program.c";
        File.WriteAllText(sourceFile, sourceCode); // Write source code to a file

        // Compile C++ code
        Process compileProcess = new Process();
        compileProcess.StartInfo.FileName = "gcc"; // You need to have g++ or any C++ compiler installed
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

    public string RunPythonProgram(string sourceCode) {

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
            return error;
        } else {
            Console.WriteLine("Python output:");
            Console.WriteLine(output);
            return output;
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

    public string RunJsProgram(string sourceCode) {
        string tempFile = "script.js"; // Path for the temporary JavaScript file

        // Write the JS code to a temporary file
        File.WriteAllText(tempFile, sourceCode);

        // Set up process info to run Node.js
        ProcessStartInfo start = new ProcessStartInfo {
            FileName = "node", // Node.js executable
            Arguments = tempFile, // Pass the temp JS file to node
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true
        };

        // Execute the JavaScript file
        using (Process process = Process.Start(start)) {
            using (StreamReader reader = process.StandardOutput) {
                string result = reader.ReadToEnd();
                return result;
            }
        }
    }
}
