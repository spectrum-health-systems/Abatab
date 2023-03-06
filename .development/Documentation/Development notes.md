# Development notes

## Script Parameters

Max length: 48 characters  
`12345678-123456789012-1234567890123456-12`  
`_________abcdAbcdefgh____________________`  
`MODULE__-COMMAND_____-ACTION__________-OP`

Module abbreviations:

* ProgNote = Progress Note
* Proto    = Prototype
* QMedOrdr = Quick Medication Order
* Testing  = Testing

Keywords: 4 characters

* Vfy  = Verify  

Other abbreviations

* Loc  = Location
* Indi = Individual/Individualized
* Inde = Independent

### TESTING

`Testing-DataDump-SessionInformation`  
`Testing-ErrorCode-ErrorCode1`  

### PROGRESSNOTE
`MODULE__-COMMAND_____-ACTION__________-OP`
`ProgNote-VfyLoc-IndiCounselingNote`  
`ProgNote-VfyLoc-GroupIndiNote`

### QUICKMEDICATIONORDER
`QMedOrdr-vfyAmount-Dose`


# Flowchart colors




`F94144`: Abatab  
`277DA1`: Core.Catalog, Module.ProgressNote  
`F3722C`: Core.DataExport, Module.Prototype  
`577590`: Core.Framework, Module.QuickMedicationOrder  
`F8961E`: Core.Logger, Module.Testing
`4D908E`: Core.Session  
`F9844A`: Core.Utilities  
`43AA8B`: ScriptLinkStandard  
`F9C74F`:  
`90BE6D`:  