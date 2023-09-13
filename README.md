# PatchIt - BinaryPatcher

BinaryPatcher is a C# class library designed for patching binary data efficiently. This library allows you to find and replace specific binary sequences within a byte array. It's particularly useful for tasks like modifying binary files, applying patches, or customizing data structures.

## What's New in Version 1.1.0.0

### Major Changes

##### Renamed the Class
- Although the namespace is the same `PatchIt`. The class name has been changed from `Patch` to `BinaryPatcher` for better clarity and consistency.

##### Library Name Constant
- Added a constant `LIB_NAME` to store the library name for consistent error messages.

##### Improved Error Handling
- Includes enhanced error handling. It provides more informative error messages and logs to help users diagnose and address issues when they occur, making it easier to pinpoint issues.

##### Logging & Null Check
- Added a `LastLog` property to provide information about the last operation's status.
- Added a null check for the input byte array in the constructor.

##### Code Refactoring
- The code has been refactored for improved readability and maintainability. Variable names and method names have been updated to be more descriptive, making it easier for developers to understand the code.

##### Additional Comments
- Includes additional comments and documentation to make the code more self-explanatory for users and developers. This documentation helps users understand how to use the class effectively (although the library is small).

### Usage

#### Using 'using' statement for proper resource disposal

```csharp
// Example usage of BinaryPatcher using the 'using' statement for proper resource disposal
using PatchIt;

// Define an array of patch pairs (find-replace) as byte arrays (must be even number of elements)
byte[][] patchPairs = { findPattern1, replacePattern1, findPattern2, replacePattern2 };
//
using (BinaryPatcher patcher = new BinaryPatcher(bytes)) {
    // Apply the patches
    patcher.PatchData(patchPairs);
    // Get the patched byte array if GetLastLog() is equal to 'Success'
    if (patcher.GetLastLog() == "Success")
        byte[] patchedData = patcher.GetPatchedBinary();
}
```

#### Without Using 'using' statement

```csharp
// Example usage of BinaryPatcher using the 'using' statement for proper resource disposal
using PatchIt;

// Initialize BinaryPatcher with a byte array
var patcher = new BinaryPatcher(byteArray);
// Define an array of patch pairs (find-replace) as byte arrays (must be even number of elements)
byte[][] patchPairs = { findPattern1, replacePattern1, findPattern2, replacePattern2 };
// Apply the patches
patcher.PatchData(patchPairs);
// Get the patched byte array if GetLastLog() is equal to 'Success'
if (patcher.GetLastLog() == "Success")
    byte[] patchedData = patcher.GetPatchedBinary();
```
---
### How to ...?
Just simply by **_finding a set of values_** and **_replacing them with another set_**, essentially using **jagged arrays**.

_After referencing the library (PatchIt.dll) or copying 'PatchIt.cs' into your project then you just include it in your project by `using PatchIt` then create the object._

_When creating the object **BinaryPatcher()** we must provide one parameter,_
- The binary data, must be stated

_When using the method **PatchData()** we must provide one parameter,_
- The jagged array or the array of `pairs`(**find binary array** and **replace binary array**) always must be an even number of arrays in `pairs`, in each `pair` the frist array is the "Find values" and the second  is the "Replace with values".

_Finally, use the method **GetPatchedData()** to write the new data to a variable._

### Simple test code review
Lets assume we have the following code
![Screenshot 2023-09-13 212616](https://github.com/AhaTheGhost/cs-patchit/assets/19475395/99e54ff2-c785-4b28-baa3-e6aab15d1b59)


The above code will result us as the following,
![Screenshot 2021-07-22 075540](https://user-images.githubusercontent.com/19475395/126592087-5d941060-6739-435c-ba34-43985b58514d.png)


The first ('F4', 'A2') was not caught, because we specifically said to match the whole array ('01', '88', 'F4', 'A2').
Furthermore,
- The first array was found and replaced.
- Nothing happened to the second array, because there wasn't such data.
- And finally, the third was also found and replaced.

_The algorithm was writing to make it as simple and as lightweight as possible with as little of **n** of **O(n)**. Also note that it will depend on your file size_

---
For more information and to access the code, please visit the [GitHub repository](https://github.com/AhaTheGhost/cs-patchit/).
If you have any questions or encounter any issues, please feel free to [reach out](mailto:ahmad360pro@gmail.com).
Thank you for using the `PatchIt-BinaryPatcher` library, and hope you find this update beneficial.
