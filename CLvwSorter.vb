Option Strict On


'// PURPOSE: The following class implements a generic sorter for ListView objects.
Public Class CLvwSorter
    Implements IComparer

    Enum colType
        colText = 0
        colNumber = 1
        colDate = 2
    End Enum

    Dim m_bIgnoreCase As Boolean
    Dim m_eSortOrder As Windows.Forms.SortOrder
    Dim m_colType As colType
    Dim m_iColNum As Integer

    '// May want to give some thought to text vs. binary comparision of strings.
    '// Use the following enumeration to allow programmers to choose between
    '// text and binary comparison.
    '// Dim m_eCompareMethod As Microsoft.VisualBasic.CompareMethod


    Public Sub New(ByVal colNumber As Integer, _
                   ByVal colType As colType, _
                   ByRef SortOrder As Windows.Forms.SortOrder)

        m_iColNum = colNumber
        m_colType = colType

        '// The default method for comparing strings is case insensitive.
        m_bIgnoreCase = True

        '// Automatically invert the sort order.
        'If SortOrder = SortOrder.Ascending Then
        SortOrder = SortOrder.Descending
        'Else
        '    SortOrder = SortOrder.Ascending
        'End If
        m_eSortOrder = SortOrder

    End Sub


    '// Use this constructor if you want to override the default for
    '// text comparison.  This constructor is meaningful when comparing
    '// strings.
    Public Sub New(ByVal colNumber As Integer, _
                   ByVal colType As colType, _
                   ByRef SortOrder As Windows.Forms.SortOrder, _
                   ByRef IgnoreCase As Boolean)

        m_iColNum = colNumber
        m_colType = colType
        m_bIgnoreCase = IgnoreCase

        '// Automatically invert sort order.
        If SortOrder = SortOrder.Ascending Then
            SortOrder = SortOrder.Descending
        Else
            SortOrder = SortOrder.Ascending
        End If
        m_eSortOrder = SortOrder

    End Sub

    Public Property ColumnNumber() As Integer
        Get
            Return m_iColNum
        End Get
        Set(ByVal Value As Integer)
            m_iColNum = Value
        End Set
    End Property


    Public Property ColumnType() As colType
        Get
            Return m_colType
        End Get
        Set(ByVal Value As colType)
            m_colType = Value
        End Set
    End Property


    Public Function CompareTo(ByVal o1 As Object, ByVal o2 As Object) As Integer _
        Implements System.Collections.IComparer.Compare

        Dim arg1 As Object
        Dim arg2 As Object
        Dim lvwItem1 As ListViewItem
        Dim lvwItem2 As ListViewItem
        lvwItem1 = CType(o1, ListViewItem)
        lvwItem2 = CType(o2, ListViewItem)

        Dim iSortVector As Integer

        Select Case m_eSortOrder
            Case SortOrder.Ascending
                iSortVector = 1
            Case SortOrder.Descending
                iSortVector = -1
            Case SortOrder.None
                iSortVector = 0
        End Select

        If m_iColNum = 0 Then
            arg1 = lvwItem1.Text
            arg2 = lvwItem2.Text
        Else
            arg1 = lvwItem1.SubItems(m_iColNum).Text
            arg2 = lvwItem2.SubItems(m_iColNum).Text
        End If

        Select Case m_colType

            Case colType.colDate
                Dim cmp1 As Date
                Dim cmp2 As Date
                cmp1 = CType(arg1, Date)
                cmp2 = CType(arg2, Date)
                Return cmp1.CompareTo(cmp2) * iSortVector

            Case colType.colNumber
                Dim cmp1 As Double
                Dim cmp2 As Double
                cmp1 = CType(arg1, Double)
                cmp2 = CType(arg2, Double)
                Return cmp1.CompareTo(cmp2) * iSortVector

            Case colType.colText
                Dim cmp1 As String
                Dim cmp2 As String
                cmp1 = CType(arg1, String)
                cmp2 = CType(arg2, String)
                Return cmp1.Compareto(cmp2) * iSortVector

        End Select

    End Function


    Public Property IgnoreCase() As Boolean
        Get
            Return m_bIgnoreCase
        End Get
        Set(ByVal Value As Boolean)
            m_bIgnoreCase = Value
        End Set
    End Property


    Public Sub InvertSortOrder()
        If m_eSortOrder = SortOrder.Ascending Then
            m_eSortOrder = SortOrder.Descending
        Else
            m_eSortOrder = SortOrder.Ascending
        End If
    End Sub


    Public Property SortOrder() As Windows.Forms.SortOrder
        Get
            Return m_eSortOrder
        End Get
        Set(ByVal Value As Windows.Forms.SortOrder)
            m_eSortOrder = Value
        End Set
    End Property


End Class

