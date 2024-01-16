Option Explicit On
Option Strict On
Option Infer On

Imports ado
Imports System.Data.SqlClient

Imports System.Configuration
Public Class ClassEmpleados
    Implements IDisposable

    Private disposedValue As Boolean

    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: eliminar el estado administrado (objetos administrados)
            End If

            ' TODO: liberar los recursos no administrados (objetos no administrados) y reemplazar el finalizador
            ' TODO: establecer los campos grandes como NULL
            disposedValue = True
        End If
    End Sub

    ' ' TODO: reemplazar el finalizador solo si "Dispose(disposing As Boolean)" tiene código para liberar los recursos no administrados
    ' Protected Overrides Sub Finalize()
    '     ' No cambie este código. Coloque el código de limpieza en el método "Dispose(disposing As Boolean)".
    '     Dispose(disposing:=False)
    '     MyBase.Finalize()
    ' End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        ' No cambie este código. Coloque el código de limpieza en el método "Dispose(disposing As Boolean)".
        Dispose(disposing:=True)
        GC.SuppressFinalize(Me)
    End Sub
    Public Class EmpleadoModel
        Public Property ID As Integer
        Public Property Nombre As String
        ' Otras propiedades según tu modelo
    End Class
    Public Function ListarEmpleado() As DataTable
        Try
            'Using cn = New conexion(ConfigurationManager.ConnectionStrings("GestionDeEmpleadosEntities").ConnectionString)
            Using cn = New conexion()

                Dim empleados As DataTable = cn.SQL("select * from vw_empleados", "tblEmpleados").Tables(0)
                ListarEmpleado = empleados
            End Using

        Catch ex As Exception
            Return New DataTable
        End Try
    End Function
    Public Function ListarVacacionesEmpleado(ByVal idEmpleado As Integer) As DataTable
        Try
            'Using cn = New conexion(ConfigurationManager.ConnectionStrings("GestionDeEmpleadosEntities").ConnectionString)
            Using cn = New conexion()

                Dim empleados As DataTable = cn.SQL(" select FechaInicio,FechaFin,(DATEDIFF(DAY, FechaInicio, FechaFin)+1)AS Vacaciones_Tomadas from Vacaciones where EmpleadoId='" & idEmpleado & "'", "tblVacaciones").Tables(0)
                ListarVacacionesEmpleado = empleados
            End Using

        Catch ex As Exception
            Return New DataTable
        End Try
    End Function
    Public Function AgregarEmpleados(ByVal nombre As String, ByVal tipoid As String, ByVal id As String, ByVal f_ingreso As Date, ByVal salario As Double, ByVal direccion As String) As String
        Try
            Dim Resultado As DataSet
            'Using cn = New conexion(ConfigurationManager.ConnectionStrings("GestionDeEmpleadosEntities").ConnectionString)
            Using cn = New conexion()
                Dim parametro1 As New SqlParameter("@NombreCompleto", SqlDbType.VarChar)
                parametro1.Value = nombre
                Dim parametro2 As New SqlParameter("@TipoIdentificacion", SqlDbType.VarChar)
                parametro2.Value = tipoid
                Dim parametro3 As New SqlParameter("@NumeroIdentificacion", SqlDbType.VarChar)
                parametro3.Value = id
                Dim parametro4 As New SqlParameter("@FechaIngreso", SqlDbType.Date)
                parametro4.Value = f_ingreso
                Dim parametro5 As New SqlParameter("@SalarioBaseMensual", SqlDbType.Float)
                parametro5.Value = salario
                Dim parametro6 As New SqlParameter("@Direccion", SqlDbType.VarChar)
                parametro6.Value = direccion

                ' Llamar a la función exec_sp con los parámetros
                Dim parametros As SqlParameter() = {parametro1, parametro2, parametro3, parametro4, parametro5, parametro6}
                Resultado = cn.exec_sp("sp_InsertarEmpleado", parametros)
                'Dim empleados As String = cn.SQL("select * from vw_empleados", "tblEmpleados")
            End Using

        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function AgregarVacaciones(ByVal id As Integer, ByVal inicio_vacaciones As Date, ByVal fin_vacaciones As Date) As String
        Try
            Dim Resultado As DataSet
            Using cn = New conexion()
                Dim parametro1 As New SqlParameter("@EmpleadoId", SqlDbType.Int)
                parametro1.Value = id
                Dim parametro2 As New SqlParameter("@FechaInicio", SqlDbType.Date)
                parametro2.Value = inicio_vacaciones
                Dim parametro3 As New SqlParameter("@FechaFinal", SqlDbType.Date)
                parametro3.Value = fin_vacaciones



                Dim parametros As SqlParameter() = {parametro1, parametro2, parametro3}
                Resultado = cn.exec_sp("sp_Vacaciones", parametros)

            End Using

        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
End Class
