@ECHO OFF
echo Generating AES Key...
bitsadmin.exe /transfer "AES" "https://fortniteassistant.xyz/aes.txt" "%cd%\AES.txt" >nul
set /p aes=<AES.txt
echo AES Key Succesfully Generated!
