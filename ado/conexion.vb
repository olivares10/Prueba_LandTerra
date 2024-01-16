Option Explicit On
Option Strict On
Option Infer On
Imports System.Data.SqlClient
Public Class conexion
    Implements IDisposable

    Public m_coneccion As String
    Private disposedValue As Boolean

    'Sub New(ByVal strcon As String)  'Inicializacion de la Instancia
    '    m_coneccion = strcon
    'End Sub

    Public Function SQL(ByVal strSql As String, ByVal NombreTabla As String) As DataSet
        m_coneccion = Configuration.ConfigurationManager.ConnectionStrings("GestionDeEmpleados_db").ConnectionString

        Using cnConec As New SqlConnection(m_coneccion)
            Try
                cnConec.Open()
                Dim daAdaptador As New SqlDataAdapter(strSql, cnConec)
                Dim dsSQL As New DataSet()
                daAdaptador.Fill(dsSQL, "tblTemp")
                daAdaptador.Dispose()
                SQL = dsSQL
            Catch ex As SqlException
                Return Nothing
            Finally
                cnConec.Close()
            End Try
        End Using
    End Function
    Public Function exec_sp(ByVal strSql_comando As String, ByVal parametros As SqlParameter()) As DataSet
        m_coneccion = Configuration.ConfigurationManager.ConnectionStrings("GestionDeEmpleados_db").ConnectionString
        Dim dsSQL As New DataSet()
        Using cnConec As New SqlConnection(m_coneccion)
            Try
                cnConec.Open()

                Dim cmdComando As New SqlCommand()
                cmdComando.Connection = cnConec
                cmdComando.CommandType = CommandType.StoredProcedure
                cmdComando.CommandText = strSql_comando

                ' Agregar parámetros al comando si los hay
                If parametros IsNot Nothing Then
                    cmdComando.Parameters.AddRange(parametros)
                End If
                cmdComando.ExecuteNonQuery()
                'Dim daAdaptador As New SqlDataAdapter(cmdComando)
                'daAdaptador.Fill(dsSQL)
                'cmdComando.Transaction = trEmpezarTransaccion

            Catch ex As SqlException
                Return Nothing
            Finally
                cnConec.Close()
            End Try
        End Using
    End Function



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
End Class
