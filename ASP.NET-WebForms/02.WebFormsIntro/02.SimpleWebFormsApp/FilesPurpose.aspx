<%@ Page  Title="Files Purpose" Language="C#" AutoEventWireup="true" CodeBehind="FilesPurpose.aspx.cs" MasterPageFile="~/Site.Master" Inherits="_02.SimpleWebFormsApp.FilesPurpose" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <div class="jumbotron">
        <h2>App_Start folder</h2>
        <p>
            By convention this folder contains configuration files that are called only
                    on the applications startup.
        </p>

        Files:
        <ul>
            <li>
                <strong>BundleConfig:</strong>
                <p>
                    Configuration about taking all javascript and css files, minify them and send them as one single file.
                </p>
            </li>
            <li>
                <strong>IdentityConfig:</strong>
                <p>
                    All the configurations about creating a new user in the application like password restriction, unique email, etc.
                </p>
            </li>
            <li>
                <strong>RouteConfig:</strong>
                <p>
                    Generally in ASP.NET this file is responsible for the way how a specific route get to a specific piece of code to be executed.
                    Specially in Web Forms the default configurations just make the application URL-s more user-friendly.
                </p>
            </li>
            <li>
                <strong>Startup.Auth:</strong>
                <p>
                    This file stores settings for the user authentication providers for the application.
                </p>
            </li>
        </ul>

    </div>

    <div class="jumbotron">
        <h2>Content folder</h2>
        <p>
            In this folder are stored all the static files for the UI of the application like .css files and images.
        </p>
    </div>

    <div class="jumbotron">
        <h2>Fonts folder</h2>
        <p>
            This folder comes with the bootstrap library and there are all needed <a href="http://getbootstrap.com/components/" target="_blank">glyphicons</a>.
        </p>
    </div>

    <div class="jumbotron">
        <h2>Models folder</h2>
        <p>
            This folder is designed for the
            <a href="http://www.asp.net/mvc/overview/older-versions/mvc-music-store/mvc-music-store-part-3" target="_blank">view models</a>
            (the way we pass data to the UI pages).

            In Web Forms this folder contains the Database model of the Application User and the DbContext class,
            which should be moved in another assembly (like .Data project).
        </p>
    </div>

    <div class="jumbotron">
        <h2>Scripts folder</h2>
        <p>
            This folder contains all the javascript files that are used in the application.
            Besides the javascript libraries that we install (like jQuery, bootstrap, etc.),
            in this folder are all the client javascript files that the 
            <a href="http://www.asp.net/web-forms/videos/building-35-applications/intro-to-aspnet-controls" target="_blank">Web Forms controlls
            </a>
            need to work properly.
        </p>
    </div>

    <div class="jumbotron">
        <h2>Account folder</h2>
        <p>
            This folder complete .aspx pages for the users of the application like Login page, Register page, etc.
        </p>
    </div>

    <div class="jumbotron">
        <h2>Another files:</h2>
        <ul>
            <li>
                <h3>.aspx pages (Default.aspx, Contact.aspx, About.aspx)</h3>
                <p>
                    Every single .aspx file (along with his .aspx.cs file) establish a complete HTML page.
                    The .aspx file contains the markup of the page and the .aspx.cs file contains the
                    <a href="https://msdn.microsoft.com/en-us/library/015103yb.aspx" target="_blank">code behind</a>
                    of that page.
                </p>
            </li>
            <li>
                <h3>Site.Master and Site.Mobile.Master</h3>
                <p>
                    The Site.Master file allow you to create a consistent look and behavior for all the pages (or group of pages) 
                    in your web application and provides a template for other pages, with shared layout and functionality.

                    The Site.Mobile.Master does the same thing, but it defines how the layout looks in mobile version.
                </p>
            </li>
            <li>
                <h3>ViewSwitcher.ascx</h3>
                <p>
                    The ViewSwitcher decides which Site.Master should be used - the default one or the Mobile one.
                </p>
            </li>
            <li>
                <h3>Global.asax</h3>
                <p>
                    This is the entry point of the application.
                    The class inside - Application_Start is instanced only once on the startup of the application
                    and is "alive" until the application goes down.
                </p>
            </li>
            <li>
                <h3>packages.config</h3>
                <p>
                    This file carries information about the installed packages for the application.
                </p>
            </li>
            <li>
                <h3>Startup.cs</h3>
                <p>
                    This file gives the opportunity to host our application without
                    <a href="https://www.iis.net/" target="_blank">IIS</a>
                    thanks to the
                    <a href="https://en.wikipedia.org/wiki/Open_Web_Interface_for_.NET" target="_blank">OWIN standard</a>.
                </p>
            </li>
            <li>
                <h3>Web.config</h3>
                <p>
                    This file contains global configurations for the application.
                    It is verry usefull becouse those configurations can be changed without recompile of the application.
                    A few configurations that Web.config holds: connection string, assembly bindings, .NET framework version,
                    roles, sessions, etc.
                </p>
            </li>
        </ul>
    </div>
</asp:Content>
