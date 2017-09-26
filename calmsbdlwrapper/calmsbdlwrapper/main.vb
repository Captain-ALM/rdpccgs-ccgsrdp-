Imports Microsoft.SmallBasic.Library
Imports System.Net

<SmallBasicType()>
Public Module main
    Public Function downloadfile(fileurl As Primitive, filelocal As Primitive) As Primitive
        Dim result As String
        Try
            Dim webc As New WebClient()
            webc.DownloadFile(fileurl.ToString, filelocal.ToString)
            result = True
        Catch ex_10 As Exception
            result = False
        End Try
        Return New Primitive(result)
    End Function

    Public Function downloadstring(fileurl As Primitive) As Primitive
        Return New Primitive(New WebClient().DownloadString(fileurl.ToString))
    End Function
End Module
