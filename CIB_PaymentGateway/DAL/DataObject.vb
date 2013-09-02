Imports  System
Imports System.Collections.Generic
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections

<Serializable()> _
Public Class DataObject
    Private _fields As New ArrayList()
    Private _rows As New List(Of DataObjectRow)()
    Private firstrow As Boolean = True

    Public Sub New(objDataReader As IDataReader)
        Dim dc As DataTable = objDataReader.GetSchemaTable()

        If Not objDataReader.IsClosed Then
            While objDataReader.Read()
                Dim dataRow As Object() = New Object(objDataReader.FieldCount - 1) {}
                Dim i As Integer = 0

                If firstrow Then
                    For Each row As DataRow In dc.Rows

                        _fields.Add(DirectCast(row("columnname"), String))
                        i += 1
                    Next

                    firstrow = False
                End If

                _rows.Add(New DataObjectRow(_fields, objDataReader))
            End While

            dc.Clear()
            objDataReader.Close()
            firstrow = True
        End If
        dc.Clear()
        objDataReader.Close()
    End Sub

    Public ReadOnly Property Rows() As List(Of DataObjectRow)
        Get
            Return _rows
        End Get
    End Property
End Class


Public Class DataObjectRow
    Private _values As New ArrayList()
    Private _fields As ArrayList = Nothing

    Public Sub New(ByRef fields As ArrayList, values As IDataReader)
        _fields = fields

        Dim i As Integer = 0
        While i < values.FieldCount
            _values.Add(values.GetValue(i))
            i += 1

        End While
    End Sub

    Public Function [Get](Key As String) As Object
        Dim lowerKey As String = Key.ToLowerInvariant()
        Dim counter As Integer = 0
        While counter < _fields.Count
            If _fields(counter).ToString().ToLowerInvariant() = lowerKey Then
                Return _values(counter)
            End If
            counter += 1
        End While
        Return Nothing
    End Function

    Public Function HasValue(Key As String) As [Boolean]
        Dim lowerKey As String = Key.ToLowerInvariant()
        Dim counter As Integer = 0
        While counter < _fields.Count
            If _fields(counter).ToString().ToLowerInvariant() = lowerKey Then
                If _values(counter) IsNot Nothing Then
                    If _values(counter).ToString() <> DBNull.Value.ToString() Then
                        Return True
                    End If
                End If
            End If
            counter += 1
        End While
        Return False
    End Function

    'public object GetValue(string Key, Delegate DataMember)
    '{
    '    string lowerKey = Key.ToLowerInvariant();
    '    object objDataValue = null;
    '    int cnt = 0;
    '    while (cnt < _fields.Count && objDataValue == null)
    '    {
    '        if (((string)_fields[cnt]).ToLowerInvariant() == lowerKey)
    '            if (_values[cnt] != null)
    '                if (_values[cnt] != DBNull.Value)
    '                    objDataValue = _values[cnt];
    '        cnt++;
    '    }

    '    return Convert.ChangeType(objDataValue, DataMember.GetType());
    '}

End Class


