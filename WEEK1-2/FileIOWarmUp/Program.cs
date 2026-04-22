// Create a new Console App and use it to run the following exercises: 

// Create a string array with the lines of text
string[] lines = { "First line", "Second line", "Third line" };

// Set a variable to the Documents path.
string docPath =
    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

// Exact file location
string filePath = Path.Combine(docPath, "Writelines.txt");


// 1. Synchronously write text with StreamWriter
// Write the string array to a new file named "WriteLines.txt".
//using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "Writelines.txt")))
//{
//    foreach (string line in lines)
//        outputFile.WriteLine(line);
//}

// Make #1 into a method.
void WriteFile (string filePath, string[] lines)
{
    File.WriteAllLines (filePath, lines);
}

// The example creates a file named "WriteLines.txt" with the following contents:
// First line
// Second line
// Third line

// 2. Read the file that you just wrote
//try
//{
//    // Open the text file using a stream reader.
//    using StreamReader reader = new(filePath);

//    // Read the stream as a string.
//    string text = reader.ReadToEnd();

//    // Write the text to the console.
//    Console.WriteLine(text);
//}

//catch (IOException e) 
//{
//    Console.WriteLine("The file could not be read:");
//    Console.WriteLine(e.Message);
//}

//Make #2 into a method.
string ReadFile(string filePath)
{
    try
    {
        return File.ReadAllText(filePath);
    }
    catch (IOException)
    {
        return "Error reading file.";
    }
}

// Now test if #1 and #2 work by calling those 2 methods with data we sent up at the start.
WriteFile(filePath, lines); // 1. Write the text to the file
string text = ReadFile (filePath); // 2. Read the file from the file
Console.WriteLine(text); // 3. Output the text to the console