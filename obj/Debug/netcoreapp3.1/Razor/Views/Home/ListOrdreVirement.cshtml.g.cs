#pragma checksum "C:\Users\MON PC\Desktop\c# et la programmation .net\projet_migration_copie\gestion_ordre_mission\Views\Home\ListOrdreVirement.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "58222a93a0321bc021913103f0b1f7dda72bc519"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ListOrdreVirement), @"mvc.1.0.view", @"/Views/Home/ListOrdreVirement.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 4 "C:\Users\MON PC\Desktop\c# et la programmation .net\projet_migration_copie\gestion_ordre_mission\Views\Home\ListOrdreVirement.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58222a93a0321bc021913103f0b1f7dda72bc519", @"/Views/Home/ListOrdreVirement.cshtml")]
    public class Views_Home_ListOrdreVirement : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<gestion_ordre_mission.Models.OrdreVirement>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("page-top"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\MON PC\Desktop\c# et la programmation .net\projet_migration_copie\gestion_ordre_mission\Views\Home\ListOrdreVirement.cshtml"
   Layout = "~/Views/Shared/MenuPersonneLayout.cshtml"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
            WriteLiteral("<!DOCTYPE html>\n<html lang=\"en\">\n\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "58222a93a0321bc021913103f0b1f7dda72bc5193762", async() => {
                WriteLiteral("\n\n    <meta charset=\"utf-8\">\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1, shrink-to-fit=no\">\n    <meta name=\"description\"");
                BeginWriteAttribute("content", " content=\"", 402, "\"", 412, 0);
                EndWriteAttribute();
                WriteLiteral(">\n    <meta name=\"author\"");
                BeginWriteAttribute("content", " content=\"", 438, "\"", 448, 0);
                EndWriteAttribute();
                WriteLiteral(@">

    <title>Ordre Mission</title>

    <!-- Custom fonts for this template -->
    <link href=""../Scripts/vendor/fontawesome-free/css/all.min.css"" rel=""stylesheet"" type=""text/css"">
    <link href=""https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i""
          rel=""stylesheet"">

    <!-- Custom styles for this template -->
    <link href=""../Content/css/sb-admin-2.min.css"" rel=""stylesheet"">

    <!-- Custom styles for this page -->
    <link href=""../Scripts/vendor/datatables/dataTables.bootstrap4.min.css"" rel=""stylesheet"">

");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "58222a93a0321bc021913103f0b1f7dda72bc5195896", async() => {
                WriteLiteral(@"

    <!-- Page Wrapper -->
    <div id=""wrapper"">


        <!-- End of Sidebar -->
        <!-- Content Wrapper -->
        <div id=""content-wrapper"" class=""d-flex flex-column"">

            <!-- Main Content -->
            <div style=""width:1230px"" id=""content"">

                <!-- Topbar -->
                <nav class=""navbar navbar-expand navbar-light bg-white topbar mb-4 static-top shadow"">

                    <!-- Sidebar Toggle (Topbar) -->
                    <form class=""form-inline"">
                        <button id=""sidebarToggleTop"" class=""btn btn-link d-md-none rounded-circle mr-3"">
                            <i class=""fa fa-bars""></i>
                        </button>
                    </form>



                    <!-- Topbar Navbar -->
                    <ul class=""navbar-nav ml-auto"">

                       

                        <div class=""topbar-divider d-none d-sm-block""></div>

                        <!-- Nav Item - User Information -->
                        <li class=");
                WriteLiteral(@"""nav-item dropdown no-arrow"">
                            <a class=""nav-link dropdown-toggle"" href=""#"" id=""userDropdown"" role=""button""
                               data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                                <span class=""mr-2 d-none d-lg-inline text-gray-600 small"">");
#nullable restore
#line 67 "C:\Users\MON PC\Desktop\c# et la programmation .net\projet_migration_copie\gestion_ordre_mission\Views\Home\ListOrdreVirement.cshtml"
                                                                                     Write(Context.Session.GetString("nompersonnel"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</span>
                                <img class=""img-profile rounded-circle""
                                     src=""../Content/img/undraw_profile.svg"">
                            </a>
                            <!-- Dropdown - User Information -->
                            <div class=""dropdown-menu dropdown-menu-right shadow animated--grow-in""
                                 aria-labelledby=""userDropdown"">

                                <div class=""dropdown-divider""></div>
                                <a class=""dropdown-item"" href=""#"" data-toggle=""modal"" data-target=""#logoutModal"">
                                    <i class=""fas fa-sign-out-alt fa-sm fa-fw mr-2 text-gray-400""></i>
                                    Se déconnecter
                                </a>
                            </div>
                        </li>

                    </ul>

                </nav>
                <!-- End of Topbar -->
                <!-- Begin Page Content -->
                <div class=""c");
                WriteLiteral(@"ontainer-fluid"">

                    <!-- Page Heading -->
                    <h1 class=""h3 mb-2 text-gray-800"" style=""font-size:20px;""></h1>


                    <!-- DataTales Example -->
                    <div class=""card shadow mb-4"">
                        <div class=""card-header py-3"">
                            <h6 class=""m-0 font-weight-bold text-primary""> Table des ordres de virement</h6>
                        </div>
                        <div class=""card-body"" style=""width:1090px;"">
                            <div class=""table-responsive"">
");
#nullable restore
#line 101 "C:\Users\MON PC\Desktop\c# et la programmation .net\projet_migration_copie\gestion_ordre_mission\Views\Home\ListOrdreVirement.cshtml"
                                 using (Html.BeginForm("ListOrdreVirement", "Home", FormMethod.Get))
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                    <table class=""table table-bordered"" id=""dataTable"" width=""100%"" cellspacing=""0"">
                        <thead>
                            <tr>
                                <th style=""width:800px;"">Num</th>
                                <th style=""width:900px;"">Numero de Compte</th>
                                <th style=""width:900px;"">id Admin</th>

                            </tr>
                        </thead>

                        <tbody>




");
#nullable restore
#line 118 "C:\Users\MON PC\Desktop\c# et la programmation .net\projet_migration_copie\gestion_ordre_mission\Views\Home\ListOrdreVirement.cshtml"
                             foreach (var item1 in Model)
                            {


#line default
#line hidden
#nullable disable
                WriteLiteral("            <tr>\n                <td>");
#nullable restore
#line 122 "C:\Users\MON PC\Desktop\c# et la programmation .net\projet_migration_copie\gestion_ordre_mission\Views\Home\ListOrdreVirement.cshtml"
               Write(item1.numero);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n                <td>");
#nullable restore
#line 123 "C:\Users\MON PC\Desktop\c# et la programmation .net\projet_migration_copie\gestion_ordre_mission\Views\Home\ListOrdreVirement.cshtml"
               Write(item1.numeroCompte);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n                <td>");
#nullable restore
#line 124 "C:\Users\MON PC\Desktop\c# et la programmation .net\projet_migration_copie\gestion_ordre_mission\Views\Home\ListOrdreVirement.cshtml"
               Write(item1.idAdmin);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n\n\n\n\n            </tr>\n");
#nullable restore
#line 130 "C:\Users\MON PC\Desktop\c# et la programmation .net\projet_migration_copie\gestion_ordre_mission\Views\Home\ListOrdreVirement.cshtml"
}

#line default
#line hidden
#nullable disable
                WriteLiteral("\n\n\n\n\n\n\n\n\n\n\n\n                        </tbody>\n                    </table>");
#nullable restore
#line 144 "C:\Users\MON PC\Desktop\c# et la programmation .net\projet_migration_copie\gestion_ordre_mission\Views\Home\ListOrdreVirement.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                            </div>
                        </div>
                    </div>

                </div>
                <!-- /.container-fluid -->

            </div>
            <!-- End of Main Content -->
            <!-- Footer -->
            <footer class=""sticky-footer bg-white"">
                <div class=""container my-auto"">
                    <div class=""copyright text-center my-auto"">
                        <span>Copyright &copy; Your Website 2020</span>
                    </div>
                </div>
            </footer>
            <!-- End of Footer -->

        </div>
        <!-- End of Content Wrapper -->

    </div>
    <!-- End of Page Wrapper -->
    <!-- Scroll to Top Button-->
    <a class=""scroll-to-top rounded"" href=""#page-top"">
        <i class=""fas fa-angle-up""></i>
    </a>

    <!-- Logout Modal-->
    <div class=""modal fade"" id=""logoutModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel""
         aria-hidden=""true"">
        <div class=""modal-dial");
                WriteLiteral(@"og"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"" id=""exampleModalLabel"">
                        Prêt à partir?
                    </h5>
                    <button class=""close"" type=""button"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">×</span>
                    </button>
                </div>
                <div class=""modal-body"">Sélectionnez ""Déconnexion"" ci-dessous si vous êtes prêt à mettre fin à votre session en cours.</div>
                <div class=""modal-footer"">
                    <button class=""btn btn-secondary"" type=""button"" data-dismiss=""modal"">Annuler</button>
                    <a class=""btn btn-primary"" href=""/Home/login"">Déconnexion</a>
                </div>
            </div>
        </div>
    </div>

    <!-- Bootstrap core JavaScript-->
    <script src=""../Scripts/vendor/jquery/jquery.min.js""></script>
    <script src=""../Scripts/vendo");
                WriteLiteral(@"r/bootstrap/js/bootstrap.bundle.min.js""></script>

    <!-- Core plugin JavaScript-->
    <script src=""../Scripts/vendor/jquery-easing/jquery.easing.min.js""></script>

    <!-- Custom scripts for all pages-->
    <script src=""../Scripts/sb-admin-2.min.js""></script>

    <!-- Page level plugins -->
    <script src=""../Scripts/vendor/datatables/jquery.dataTables.min.js""></script>
    <script src=""../Scripts/vendor/datatables/dataTables.bootstrap4.min.js""></script>

    <!-- Page level custom scripts -->
    <script src=""../Scripts/demo/datatables-demo.js""></script>

");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n\n</html>\n\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<gestion_ordre_mission.Models.OrdreVirement>> Html { get; private set; }
    }
}
#pragma warning restore 1591
