#Deleta Arquivos da Pasta %TEMP%
Remove-Item -Path "$env:TEMP\*" -Force -recurse -ErrorAction SilentlyContinue;

#Deleta Arquivos da Pasta TEMP
Remove-Item -Path "C:\Windows\Temp\*" -Force -recurse -ErrorAction SilentlyContinue;

#Deleta Arquivos da Pasta PREFETCH
Remove-Item -Path "C:\Windows\Prefetch\*" -Force -recurse -ErrorAction SilentlyContinue;

#Esvazia a Lixeira
Clear-RecycleBin -Force -ErrorAction SilentlyContinue;
