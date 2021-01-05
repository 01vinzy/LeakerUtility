@ECHO OFF
echo Generating New Map...
bitsadmin.exe /transfer "map" "https://media.fortniteapi.io/images/map.png?showPOI=false&lang=eng" "%cd%\map-poi.png" >nul
set /p map=<map-poi.png
echo Succesfully Generated New Map!