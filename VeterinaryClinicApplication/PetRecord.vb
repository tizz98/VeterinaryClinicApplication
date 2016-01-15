'------------------------------------------------------------
'-                File Name : PetRecord.vb                  - 
'-                Part of Project: Assign1                  - 
'------------------------------------------------------------ 
'-                Written By: Elijah Wilson                 - 
'-                Written On: 1/14/16                       -
'------------------------------------------------------------ 
'- File Purpose:                                            - 
'- This file contains the PetRecord class.                  - 
'------------------------------------------------------------ 
<System.Serializable> Public Class PetRecord
    Public name As String
    Public ownerName As String
    Public species As String
    Public age As String
    Public ageUnit As String
    Public isNeutered As Boolean
    Public lastVisit As String
End Class
