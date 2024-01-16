<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="Prueba_LandTerra._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
      <style type="text/css">
        #TextArea1 {
            width: 241px;
            height: 78px;
        }

        .miClaseCSS {
            /* Define tus estilos personalizados aquí */
            border: 1px solid #ccc;
            /* Otros estilos... */
        }

            .miClaseCSS tr:nth-child(even) {
                /* Estilos para filas pares */
                background-color: #f2f2f2; /* Cambia el color de fondo según tus preferencias */
            }

            .miClaseCSS tr:nth-child(odd) {
                /* Estilos para filas impares */
                background-color: #ffffff; /* Cambia el color de fondo según tus preferencias */
            }

            .miClaseCSS th, .miClaseCSS td {
                /* Estilos para celdas en general */
                border: 1px solid #ddd; /* Borde entre celdas */
                padding: 8px; /* Espaciado interno de las celdas */
                text-align: left;
            }

        }
    </style>
      <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/bootstrap.js"></script>
        <link href="Scripts/bootstrap.min.js" rel="stylesheet" />
    <link href="Scripts/bootstrap.js" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Scripts/bootstrap.js" rel="stylesheet" />
    <link rel="stylesheet" href="Scripts/bootstrap.min.css">



        <div style="height: 487px" runat="server" id="Registo">
            <br />
            <br />

            <table style="width: 100%;">
                <tr>
                    <td align="center">
                        <asp:Label ID="lblTituloFormulario" runat="server" class="btn btn-info" Text="Registro de Emplados."></asp:Label>

                    </td>
                </tr>
            </table>
            <table style="width: 100%;" class="table">
                <caption>
   
                    <tr>
                        <td>Ingrese Nombre Completo del Emplado:</td>
                        <td>
                            <asp:TextBox ID="txtname" runat="server" class="form-control"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>Seleccione el tipo de Identificacion:</td>
                        <td>
                            <asp:DropDownList ID="DropDownList1" runat="server" class="form-control">
                                <asp:ListItem>Cedula</asp:ListItem>
                                <asp:ListItem>Pasaporte</asp:ListItem>
                            </asp:DropDownList>

                            <td>&nbsp;</td>
                        </td>
                    </tr>
                    <tr>
                        <td>Ingreses numero de Identificacion:</td>
                        <td>
                            <asp:TextBox ID="txtIdentificacion" runat="server" Width="170px" class="form-control"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>Fecha de Ingreso:</td>
                        <td>
                            <%--<asp:Calendar ID="CalendarIngreso" runat="server" Height="10px" ></asp:Calendar>--%>
                            <input id="FechaIngreso" runat="server" type="date">
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>Salario Base:</td>
                        <td>
                            <asp:TextBox ID="txtSalario" runat="server" Width="170px" class="form-control" aria-label="Amount (to the nearest dollar)"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>Direccion:</td>
                        <td>
                            <textarea id="txtDirecion" name="S1" runat="server"></textarea></td>
                        <td>
                            <asp:Button ID="Button1" runat="server" Text="Guardar" />
                        </td>
                    </tr>
                </caption>
            </table>

        </div>
        <div style="height: 487px" runat="server" id="Vacaciones" visible="false">
            <br />
            <br />

            <table style="width: 100%;">
                <tr>
                    <td align="center">
                        <asp:Label ID="Label1" runat="server" Text="Registro de Vacaciones" class="btn btn-warning"></asp:Label>

                    </td>
                </tr>
            </table>
            <table style="width: 100%;" class="table">
                <asp:HiddenField ID="hfIDEmpleado" runat="server" />
                <tr>
                    <td>Emplado:</td>
                    <td>
                        <asp:TextBox ID="TextBox3" runat="server" class="form-control"></asp:TextBox></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Fecha de Inicio:</td>
                    <td>
                        <input id="inicio_vacaciones" runat="server" type="date">
                    </td>
                    <td>Fecha de Fin:</td>
                    <td>
                        <input id="fin_vacaciones" runat="server" type="date">
                    </td>

                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="Button2" runat="server" class="btn btn-primary" Text="Guardar Vacaciones" />

                    </td>
                    <td>
                        <asp:Button ID="Button3" runat="server" class="btn btn-danger" Text="Cancelar" />

                    </td>
                </tr>
            </table>
        <br />
        <br />
        <div>
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="true" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" CssClass="miClaseCSS"></asp:GridView>
        </div>
        </div>
        <br />
        <br />
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" CssClass="miClaseCSS"></asp:GridView>
        </div>
</asp:Content>
