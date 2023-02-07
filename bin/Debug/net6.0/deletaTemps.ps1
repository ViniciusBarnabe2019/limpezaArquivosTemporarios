#Deleta Arquivos da Pasta %TEMP%
Remove-Item -Path "$env:TEMP\*" -Force -Recurse -ErrorAction SilentlyContinue;

#Deleta Arquivos da Pasta TEMP
Remove-Item -Path "C:\Windows\Temp\*" -Force -Recurse -ErrorAction SilentlyContinue;

#Deleta Arquivos da Pasta PREFETCH
Remove-Item -Path "C:\Windows\Prefetch\*" -Force -Recurse -ErrorAction SilentlyContinue;

#Esvazia a Lixeira
Clear-RecycleBin -Force -ErrorAction SilentlyContinue;
