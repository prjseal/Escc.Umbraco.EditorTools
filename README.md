# Escc.Umbraco.EditorTools

Adds a new section to the Umbraco back office that displays additional information and tools for editors.

## Tools

### Users

The 'Users' tool is designed to be a quick an easy way to view all of the active and disabled users in your Umbraco installation.

This is particularly useful if a user is struggling to log in. For example they may have forgotten their username or believes their account to be disabled for some reason (Umbraco disables a user account after several failed login attempts). When not being used to troubleshoot login problems it is also a useful audit tool to see how many users you have.

If you visit the Stats tab you can see some basic statistics about your users, such as total users and a table of your user types.

### Content

The 'Content' tool queries the examine indexes and the content service for your Umbraco installation and creates a table of all of your published and unpublished content. This tool is particularly handy for audit purposes. If your site is particularly large the generation of data can take at least a minute, but is then cached for future use.

On each table for your content you are provided with the ID, Name, published URL and a link to the edit page for each content node.

If you click on the Stats tab you can see some basic statistics about all your content pages such as your total pages and a table of your document types. 

The process then goes a step further and generates a table for each document type to allow you to quickly view all the pages that fall under that type. On each table you can view basic information such as the pages name, id and published URL. Your also provided with a link to each pages edit page.

### Media

The 'Media' tool queries examine for all the media files it can find and returns them to you in a table.

You can view the name, date created, the creator and the edit link for media in this table.

If you go to the Stats tab you can view some basic statistics about your media files, such as the total media count and a table of your file types.

### Page Expiry

The 'Page Expiry' tool allows you to view all the pages in your Umbraco installation that are published and have either an expiry date or are set never to expire (they have no expiry date).

The first time the tool is opened it might take some time to load as the tool queries the content service to find expiry dates. However, once loaded, the data is cached to avoid having to do the query again. If you believe the tables to out of date you can click refresh to update the cache.

This tool is particularly useful for audit purposes and to quickly find out what pages are expiring and when or which pages will never expire.

Developers: This tool also makes use of Examine, so if you wish to speed up this tool you can install [Escc.Umbraco.Expiry](https://github.com/east-sussex-county-council/Escc.Umbraco.Expiry) to add an "expireDate" UmbracoProperty to your document types that copies the expiry date into Examine. If a result returned by Examine doesn't have this property the process then queries the content service which causes an overall slow down.

### Search

The 'Search' tool takes your search terms and queries the Examine indexes for your Umbraco installation.

Using the drop down list you can choose to either search for media files or content pages. The results are then returned to you in a table which contains the closest results that examine could find.

Both queries for either media or content allow for multiple search terms and will score the results returned to you.

### CSV Export

The 'CSV Export' tool generates a CSV file of your entire Umbraco content tree that you can download.

On particularly large websites the process will take a minimum of 30 seconds to create the CSV file. However once generated the file is cached allowing you to immediately download the file again.

If you believe the file to be out of date, simply click the refresh button to regenerate a new CSV file.

The CSV file contains the following properties for each page: Header, Document Type, Expiry Date, Edit URL and Live URL.

## Installation

1. Clone this repository.

2. Open in Visual Studio 2015 and up.

3. Use the `web.example.config` to create a `web.config` file.

4. Right click on the solution and click 'Restore Nuget Packages'.

5. Right click on the solution and click 'Manage Nuget Packages for Solution'.

6. Search for and install a copy of 'UmbracoCms'. (If you want to use an existing Umbraco database, make sure you install the same version of the UmbracoCms)

7. Right click on the solution and click 'Rebuild Solution'.

8. Use a web server such as IIS to host the project.

9. Navigate to your Umbraco installation in a browser eg https://localhost:8888/umbraco and follow the installation/upgrade process if it appears.

10. Go To the Users Tab

11. Find a User you want to be able to use the tools

12. Tick the 'Editor Tools' check box

13. Click Save. The user will see the new section when they refresh the page.