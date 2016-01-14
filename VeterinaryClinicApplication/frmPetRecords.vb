Imports System.IO
Imports System.Xml

Public Class frmPetRecords
    Private ageUnits As New List(Of String)(New String() {"Months", "Years"})
    Private isNewRecord As Boolean
    Private currentPetRecordIndex As Integer = 0
    Private petRecords As New List(Of PetRecord)
    Private Const DATAFILEPATH = "pet_records.xml"
    Private Const FORMBASETITLE = "Veterinary Clinic System"

    Private Sub frmPetRecords_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lstAgeUnits.DataSource = ageUnits

        If File.Exists(DATAFILEPATH) Then
            petRecords = getRecordsFromDataFile()
        Else
            populateDataFile(petRecords)  ' petRecords will by an empty List
        End If

        If petRecords.Count = 0 Then
            updateFormForNewRecord()
        Else
            updateFormData()
            updateFormTitlePetCount()
        End If
    End Sub

    Private Sub populateDataFile(records As List(Of PetRecord))
        Dim dataFileWriter As StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(DATAFILEPATH, False)
        Dim serializer As New Serialization.XmlSerializer(GetType(List(Of PetRecord)))
        serializer.Serialize(dataFileWriter, records)
        dataFileWriter.Close()
    End Sub

    Private Function getRecordsFromDataFile() As List(Of PetRecord)
        Dim serializer As New Serialization.XmlSerializer(GetType(List(Of PetRecord)))
        Dim dataFileReader As StreamReader = My.Computer.FileSystem.OpenTextFileReader(DATAFILEPATH)
        Dim records As List(Of PetRecord) = DirectCast(serializer.Deserialize(dataFileReader), List(Of PetRecord))

        dataFileReader.Close()
        Return records
    End Function

    Private Function getPetStringForTitle() As String
        Return String.Format("Pet {0}/{1}", currentPetRecordIndex + 1, petRecords.Count)
    End Function

    Private Sub updateFormTitlePetCount()
        Dim titleString As String = String.Format("{0} - {1}", FORMBASETITLE, getPetStringForTitle())
        Me.Text = titleString
    End Sub

    Private Sub updateFormTitleAddNewPet()
        Dim titleString As String = String.Format("{0} - Adding New Pet", FORMBASETITLE)
        Me.Text = titleString
    End Sub

    Private Sub btnNewRecord_Click(sender As Object, e As EventArgs) Handles btnNewRecord.Click
        updateFormForNewRecord()
    End Sub

    Private Sub resetAllFields()
        txtPetName.Text = ""
        txtOwnerName.Text = ""
        txtLastVisit.Text = ""
        txtAge.Text = ""
        txtSpecies.Text = ""
        chkIsNeutered.Checked = False
        lstAgeUnits.ClearSelected()
    End Sub

    Private Sub lockAllFields()
        txtPetName.Enabled = False
        txtOwnerName.Enabled = False
        txtLastVisit.Enabled = False
        txtAge.Enabled = False
        txtSpecies.Enabled = False
        chkIsNeutered.Enabled = False
        lstAgeUnits.Enabled = False
    End Sub

    Private Sub unlockAllFields()
        txtPetName.Enabled = True
        txtOwnerName.Enabled = True
        txtLastVisit.Enabled = True
        txtAge.Enabled = True
        txtSpecies.Enabled = True
        chkIsNeutered.Enabled = True
        lstAgeUnits.Enabled = True
    End Sub

    Private Sub toggleButtonsForNewRecord()
        btnGoLeft.Hide()
        btnGoRight.Hide()
        btnNewRecord.Hide()

        btnSaveRecord.Show()
        btnCancelNewRecord.Show()
    End Sub

    Private Sub toggleButtonsForExistingRecord()
        btnGoLeft.Show()
        btnGoRight.Show()
        btnNewRecord.Show()

        btnSaveRecord.Hide()
        btnCancelNewRecord.Hide()
    End Sub

    Private Sub updateFormForNewRecord()
        resetAllFields()
        unlockAllFields()
        updateFormTitleAddNewPet()
        toggleButtonsForNewRecord()
    End Sub

    Private Sub updateFormData()
        lockAllFields()
        Dim pet As PetRecord = petRecords.ElementAt(currentPetRecordIndex)
        updateFormFieldsFromPetRecord(pet)
    End Sub

    Private Sub updateFormFieldsFromPetRecord(record As PetRecord)
        txtPetName.Text = record.name
        txtOwnerName.Text = record.ownerName
        txtLastVisit.Text = record.lastVisit
        txtAge.Text = record.age
        txtSpecies.Text = record.species
        chkIsNeutered.Checked = record.isNeutered
        lstAgeUnits.SelectedIndex = ageUnits.IndexOf(record.ageUnit)
    End Sub

    Private Sub btnSaveRecord_Click(sender As Object, e As EventArgs) Handles btnSaveRecord.Click
        ' Create record in memory & then save records to file
        Dim record As PetRecord = getPetRecordFromFormFields()
        petRecords.Add(record)
        currentPetRecordIndex = petRecords.Count - 1  ' 0 based index for the List
        updateFormData()  ' show new data
        updateFormTitlePetCount()
        toggleButtonsForExistingRecord()
        populateDataFile(petRecords)
    End Sub

    Private Sub btnCancelNewRecord_Click(sender As Object, e As EventArgs) Handles btnCancelNewRecord.Click
        If petRecords.Count = 0 Then
            MessageBox.Show("There aren't any existing pet records, please create one first!")
        Else
            updateFormData()
            updateFormTitlePetCount()
            toggleButtonsForExistingRecord()
        End If
    End Sub

    Function getPetRecordFromFormFields() As PetRecord
        Dim record = New PetRecord()
        record.name = txtPetName.Text
        record.age = txtAge.Text
        record.ownerName = txtOwnerName.Text
        record.species = txtSpecies.Text
        record.lastVisit = txtLastVisit.Text
        record.isNeutered = chkIsNeutered.Checked
        record.ageUnit = ageUnits.ElementAt(lstAgeUnits.SelectedIndex)

        Return record
    End Function

    Private Sub btnGoLeft_Click(sender As Object, e As EventArgs) Handles btnGoLeft.Click
        Dim newIndex = currentPetRecordIndex - 1

        If newIndex < 0 Then
            MessageBox.Show("You cannot move past the first record!")
        Else
            currentPetRecordIndex = newIndex
            updateFormData()
            updateFormTitlePetCount()
        End If
    End Sub

    Private Sub btnGoRight_Click(sender As Object, e As EventArgs) Handles btnGoRight.Click
        Dim newIndex = currentPetRecordIndex + 1

        If newIndex > (petRecords.Count - 1) Then
            MessageBox.Show("You cannot move past the last record!")
        Else
            currentPetRecordIndex = newIndex
            updateFormData()
            updateFormTitlePetCount()
        End If
    End Sub
End Class
