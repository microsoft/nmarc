# Native Mode Alignment Tool Report Converter (NMARC)

The NMARC tool enables admins to parse the Native Mode alignment report for Yammer. This YAML file can be large
and difficult to understand with a text editor. This utility reads the YAML and outputs text files in a tabular format that 
is easier to open with Microsoft Excel, or other tools, which can process CSV.

This tool is currently in *preview* and no precompiled executable is available for download. NMARC is a Windows Forms 
application that needs to be compiled using Visual Studio 2019.

## Community Help and Support

This tool is *unsupported* by Microsoft Support (CSS). It is expected that users understand how to compile and run Visual Studio 2019
projects, or have assistance from others in their organization to do this.

[GitHub Issues](../../issues) is the best place to ask questions, report bugs, and new request features.  Updates will be 
made on a *best efforts* basis.

## Getting started

These steps are currently required to build the utility. You will need admin privileges on your machine.

1. Install Visual Studio 2019 (any edition) and make sure the *.NET desktop development* workload is selected.
2. Check out this code from GitHub.
3. Open the solution file in the `src` directory of this project.
4. Once the solution fully loads, update the NuGet packages in the project. Specifically, make sure that the YamlDotNet library is updated, or the project will not build. 
6. Audit the source code. This is optional, but you should always make sure that you are comfortable with source code that you run on your machine.
7. Build the solution. A Windows Forms executable will be produced. This can be run on other machines, but you may get a security warning.

If you experience a problem building the solution, it's most likely a generic Visual Studio, NuGet, or Windows Forms issue. Answers are can often be found very quickly via a web search.

## Contributing

This project welcomes contributions and suggestions.  Most contributions require you to agree to a
Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us
the rights to use your contribution. For details, visit https://cla.opensource.microsoft.com.

When you submit a pull request, a CLA bot will automatically determine whether you need to provide
a CLA and decorate the PR appropriately (e.g., status check, comment). Simply follow the instructions
provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or
contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

## Security Reporting

If you find a security issue with our libraries or services please report it 
to [secure@microsoft.com](mailto:secure@microsoft.com) with as much detail as possible. Your submission may be 
eligible for a bounty through the [Microsoft Bounty](http://aka.ms/bugbounty) program. Please do not post 
security issues to GitHub Issues or any other public site. We will contact you shortly upon receiving the information. 
We encourage you to get notifications of when security incidents occur by 
visiting [this page](https://technet.microsoft.com/en-us/security/dd252948) and subscribing to Security Advisory Alerts.