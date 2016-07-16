Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions

Public Class Form1
    '中文註解前面打//

#Region "事件"
    ''' <summary>
    ''' 按鍵Transfer,讀取txtBefore,處理後,寫入txtAfter txtSD
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnTran_Click(sender As Object, e As EventArgs) Handles btnTran.Click
        VBFormat.SetCustomFormat(parasCustom:=txtListName.Text, sdCustom:=txtDictionaryName.Text) '靜態寫法,破壞可讀性
        Dim sqlToVB As ISQLToVB = New SQLToVB(TransType.SQLToVB, WithOrWithoutNote) '預設為VBWithoutNoteFactory
        Dim vbCode = sqlToVB.Transfer(strBefore:=txtLeft.Text)
        txtRight.Text = vbCode.VBText
        txtSD.Text = vbCode.SDText
    End Sub

    ''' <summary>
    ''' 將VBCode轉成SQL
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnInverse_Click(sender As Object, e As EventArgs) Handles btnInverse.Click
        VBFormat.SetCustomFormat(parasCustom:=txtListName.Text, sdCustom:=txtDictionaryName.Text) '靜態寫法,破壞可讀性
        Dim vbToSQL As ISQLToVB = New SQLToVB(TransType.VBToSQL, WithOrWithoutNote) '預設為VBWithoutNoteFactory
        Dim sqlCode = vbToSQL.Transfer(strBefore:=txtRight.Text)
        txtLeft.Text = sqlCode.SQLText
    End Sub

    ''' <summary>
    ''' 清除文字
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCls_Click(sender As Object, e As EventArgs) Handles btnCls.Click
        txtLeft.Text = String.Empty
        txtRight.Text = String.Empty
        txtSD.Text = String.Empty
    End Sub

#End Region

#Region "函式"
    Private ReadOnly Property WithOrWithoutNote As NoteType
        Get
            If rdoWithNote.Checked Then
                Return NoteType.WithNote
            ElseIf rdoWithoutNote.Checked Then
                Return NoteType.WithoutNote
            Else
                Return NoteType.WithoutNote
            End If
        End Get
    End Property
#End Region
    
End Class
