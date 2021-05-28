Imports Microsoft.SmallBasic.Library
Imports System.Reflection
''' <summary>
''' Provides a way of starting the current application again
''' </summary>
''' <remarks></remarks>
<SmallBasicType()>
Public Module SBRelaunchExtension
    ''' <summary>
    ''' Attempts to start the program with the specified arguments
    ''' Program.End() still needs to be called after!
    ''' </summary>
    ''' <param name="arguments">The arguments to pass to the started application</param>
    ''' <returns>The session ID of the started application</returns>
    ''' <remarks></remarks>
    Public Function relaunchprogram(arguments As Primitive) As Primitive
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
    Public Function relaunchprogramasadmin(arguments As Primitive) As Primitive
        Dim hostapp As String = Assembly.GetEntryAssembly.Location
        If arguments.ToString <> "" Then
            Return New Primitive(Process.Start(New ProcessStartInfo() With {.FileName = hostapp, .Arguments = arguments.ToString, .Verb = "runas"}).SessionId)
        Else
            Return New Primitive("")
        End If
    End Function
    ''' <summary>
    ''' Gets the path of the executing assembly
    ''' </summary>
    ''' <returns>The path of the executing assembly</returns>
    ''' <remarks></remarks>
    Public Function programPath() As Primitive
        Return Assembly.GetEntryAssembly.Location
    End Function
End Module
