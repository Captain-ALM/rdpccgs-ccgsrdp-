Imports Microsoft.SmallBasic.Library
Imports System.Reflection
''' <summary>
''' Provides a way of starting the current application again
''' </summary>
''' <remarks></remarks>
<SmallBasicType()>
Public Module main
    ''' <summary>
    ''' Attempts to start the program with the specified arguments
    ''' Program.End() still needs to be called after!
    ''' </summary>
    ''' <param name="arguments">The arguments to pass to the started application</param>
    ''' <returns>The session ID of the started application</returns>
    ''' <remarks></remarks>
    Public Function restartprogram(arguments As Primitive) As Primitive
        Dim hostapp As String = Assembly.GetEntryAssembly.Location
        If arguments.ToString <> "" Then
            Return New Primitive(Process.Start(hostapp, arguments.ToString).SessionId)
        Else
            Return New Primitive("")
        End If
    End Function
    ''' <summary>
    ''' Attempts to start the program with the specified arguments with a UAC prompt
    ''' Program.End() still needs to be called after!
    ''' </summary>
    ''' <param name="arguments">The arguments to pass to the started application</param>
    ''' <returns>The session ID of the started application</returns>
    ''' <remarks></remarks>
    Public Function restartprogramasadmin(arguments As Primitive) As Primitive
        Dim hostapp As String = Assembly.GetEntryAssembly.Location
        If arguments.ToString <> "" Then
            Return New Primitive(Process.Start(New ProcessStartInfo() With {.FileName = hostapp, .Arguments = arguments.ToString, .Verb = "runas"}).SessionId)
        Else
            Return New Primitive("")
        End If
    End Function
End Module
