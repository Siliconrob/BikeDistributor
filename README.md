# Bike Distributor - From :chestnut: to :deciduous_tree:

## My Build Environment

* .NET Core Standard 1.6
* .NET Core App 1.1 - for xUnit test project
* Windows 10

## Tools used to create

* Visual Studio 2017 - Tried using some other environments like Project Rider from JetBrains (project is coming along well though), but came back to this for immediate productivity
* xUnit for tests - I know NUnit better, but xUnit seems clean and simple and also is a default in Visual Studio
* As these tools and frameworks are new, so I would recommend the same environment and tools initially or send me a GitHub Issue and I will fix it or Pull Requests are welcome.

## Dependencies used and why

* ServiceStack.Text.Core - It is the best JSON handling simple library available in .NET period :zap:.  Json.NET so fat and useless :whale:
* Markdig - Writing markdown is much easier than writing HTML also most everyone can do it easy enough.  Case in point GitHub uses markdown

## Design Decision Guidelines

After working in JavaScript and dabbling with F# I like to write C# code in a functional manner as it reduces cognitive load.

* Data objects are simple POCO classes
* Business and manipulation logic is written in a static class methods or extensions because composition and pipelines are better than inheritance in practice as I have discovered after programming many codebases.
* Func<T1, ..> are your friends in C# to do pattern matching as you can create 'pure' functions that take an input produces an output and do not hold state.  C# language is increasingly becoming more and more functional like JavaScript especially ReactJS/Redux (I would recommend to use ReactJS/Redux as your renderer and keep C# as your web service API, ServiceStack is the best here) as it makes writing test code so much easier.
* JSON is the lingua franca of modern development so whenever possible I used it as the serialized data system for tests and communication.  HTML is a render component and as such is a brittle data exchange format and XML is for legacy systems and grandpas :older_man:.

## Process

I went back to the original code and thought about the plain objects that would be passed around and how a receipt works when you make orders online and what you expect.  Here I found that the Bike class is the start, but there are some key missing data constructs needed, there are customers, locations, addresses, etc.  Additionally the Bike order itself seems to be close to what a would be stored in a database of some type, but a receipt is a different type of data object and should sit at the presentation layer and be rendered out from the contents of the Bike.

I have revamped the code to have a Location project to hold location details associated with an order/customer, a Receipt project which acts as a business layer calculator to take Bike orders from a data storage format and convert them to the presentation layer Receipts, and finally I added a Html conversion engine which currently is a simple veneer over a Markdig because Markdown is easy to understand and format and that is why everyone uses it :thumbsup:.

I do not have many comments in the code because I try to be like Kent Beck 'When you feel the need to write a comment, first try to refactor the code so that any comment becomes superfluous', but I know I am not as good as him so always open to ideas on how to refactor the code the make it follow the principles of least astonishment on what things do.

Enjoyed the task as it gave me time to practice with new technologies and the impetus to actually create something of value.

:monkey_face:
