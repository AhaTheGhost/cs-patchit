### What is CS PatchIt?
It is a super easy library to edit binary files as to your need for.

### How to use it?
just simply by **_finding a set of values_** and **_replacing them with another set_**, essentially using **jagged arrays**.

_After referencing the library (PatchIt.dll) into your project then we just create the object._

_When creating the object **Patch()** we must provide one parameters,_
1. The binary data, must be stated

_When using the method **patchData()** we must provide one parameter,_
1. The jagged array (array of arrays) always must be an even number of arrays, every odd array is the "Find values" and every even array is the "Replace with values".

Finally, use the method _getPatchedData()_ to write the new data to a variable.

### Simple test code review
Lets assume we have the following code
![Screenshot 2021-07-22 074315](https://user-images.githubusercontent.com/19475395/126592184-e920d846-53ea-4fa8-aa31-bc7022b944a5.png)


The above code will result us as the following,
![Screenshot 2021-07-22 075540](https://user-images.githubusercontent.com/19475395/126592087-5d941060-6739-435c-ba34-43985b58514d.png)


The first ('F4', 'A2') was not caught, because we specifically said to match the whole array ('01', '88', 'F4', 'A2').
Furthermore,
- The first array was found and replaced.
- Nothing happened to the second array, because there wasn't such data.
- And finally, the third was also found and replaced.

_The algorithm was writing to make it as simple and as lightweight as possible with as little of **n** of **O(n)**. Also note that it will depend on your file size_
