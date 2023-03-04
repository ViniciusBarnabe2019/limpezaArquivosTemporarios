# Função que deleta arquivos
function deletaArquivos {
	param($pasta)
    if($pasta -eq "temp1") {
        Remove-Item -Path "$env:TEMP\*" -Force -Recurse -ErrorAction SilentlyContinue
    }
    elseif($pasta -eq "temp2") {
        Remove-Item -Path "C:\Windows\Temp\*" -Force -Recurse -ErrorAction SilentlyContinue
    }
    elseif($pasta -eq "pref") {
        Remove-Item -Path "C:\Windows\Prefetch\*" -Force -Recurse -ErrorAction SilentlyContinue
    }
    elseif($pasta -eq "recent") {
        Remove-Item -Path "$ENV:UserProfile\AppData\Roaming\Microsoft\Windows\Recent\*" -Force -Recurse -ErrorAction SilentlyContinue
    }
    elseif($pasta -eq "lixeira") {
        Clear-RecycleBin -Force -ErrorAction SilentlyContinue
    }
}

# Deleta arquivos da pasta Temp1
deletaArquivos -pasta "temp1"

# Deleta arquivos da pasta Temp2
deletaArquivos -pasta "temp2"

# Esvazia a Lixeira
deletaArquivos -pasta "lixeira"

# Deleta arquivos da pasta Prefetch
deletaArquivos -pasta "pref"

# Deleta arquivos da Pasta Recents
deletaArquivos -pasta "recent"
