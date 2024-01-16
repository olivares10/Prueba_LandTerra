Imports Negocio
Public Class _Default
    Inherits Page




    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CargarReporte()
    End Sub

    Private Sub CargarEditar(ByVal IDTransaccion As Integer)


    End Sub

    Private Sub CargarReporte()
        Dim Resultado As DataTable
        Using ls = New ClassEmpleados()
            Resultado = ls.ListarEmpleado()
            GridView1.DataSource = Resultado
            GridView1.DataBind()
        End Using

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs)

        Registo.Visible = False
        Vacaciones.Visible = True
        Dim index As Integer = GridView1.SelectedIndex
        If index >= 0 AndAlso index < GridView1.Rows.Count Then
            Dim filaSeleccionada As GridViewRow = GridView1.Rows(index)

            hfIDEmpleado.Value = filaSeleccionada.Cells(1).Text
            TextBox3.Text = filaSeleccionada.Cells(2).Text

            Dim Resultado As DataTable
            Using ls = New ClassEmpleados()
                Resultado = ls.ListarVacacionesEmpleado(hfIDEmpleado.Value)
                GridView2.DataSource = Resultado
                GridView2.DataBind()
            End Using
        End If


    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Resultado As String
        Using ls = New ClassEmpleados()
            Resultado = ls.AgregarVacaciones(hfIDEmpleado.Value, inicio_vacaciones.Value, fin_vacaciones.Value)

        End Using
        If Resultado Is Nothing Then
            CargarReporte()
            txtname.Text = ""
            DropDownList1.SelectedValue = "Cedula"
            txtIdentificacion.Text = ""
            FechaIngreso.Value = ""
            inicio_vacaciones.Value = ""
            fin_vacaciones.Value = ""
            txtSalario.Text = ""
            txtDirecion.Value = ""
            hfIDEmpleado.Value = ""
            Registo.Visible = True
            Vacaciones.Visible = False
        End If


    End Sub
    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        CargarReporte()
        txtname.Text = ""
        DropDownList1.SelectedValue = "Cedula"
        txtIdentificacion.Text = ""
        FechaIngreso.Value = ""
        inicio_vacaciones.Value = ""
        fin_vacaciones.Value = ""
        txtSalario.Text = ""
        txtDirecion.Value = ""
        hfIDEmpleado.Value = ""
        Registo.Visible = True
        Vacaciones.Visible = False
    End Sub


    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Resultado As String
        Using ls = New ClassEmpleados()
            Resultado = ls.AgregarEmpleados(txtname.Text, DropDownList1.Text, txtIdentificacion.Text, FechaIngreso.Value, txtSalario.Text, txtDirecion.Value)

        End Using
        If Resultado Is Nothing Then
            CargarReporte()
            txtname.Text = ""
            DropDownList1.SelectedValue = "Cedula"
            txtIdentificacion.Text = ""
            FechaIngreso.Value = ""
            txtSalario.Text = ""
            txtDirecion.Value = ""
        End If
        'CargarReporte()
    End Sub

End Class