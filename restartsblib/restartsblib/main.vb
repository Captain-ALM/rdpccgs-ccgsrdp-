Imports Microsoft.SmallBasic.Library
Imports System.Reflection

<SmallBasicType()>
Public Module main

    Public Function restartprogram(arguments As Primitive) As Primitive
        Dim hostapp As String = Assembly.GetEntryAssembly.Location
        If arguments.ToString <> "" Then
            Return New Primitive(Process.Start(hostapp, arguments.ToString).SessionId)
        Else
            Return New Primitive("")
        End If
    End Function

    Public Function restartprogramasadmin(arguments As Primitive) As Primitive
        Dim hostapp As String = Assembly.GetEntryAssembly.Location
        If arguments.ToString <> "" Then
            Return New Primitive(Process.Start(New ProcessStartInfo() With {.FileName = hostapp, .Arguments = arguments.ToString, .Verb = "runas"}).SessionId)
        Else
            Return New Primitive("")
        End If
    End Function
End Module
