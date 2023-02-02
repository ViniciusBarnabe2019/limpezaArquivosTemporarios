using System.IO; 
using System.Collections.Generic;

class Pastas {
	//Pega o Diretório da Pasta TEMP
	private DirectoryInfo temp1 { get; set; } = new DirectoryInfo(@"C:\Windows\Temp\");
	
	//Pega o Diretório da Pasta %TEMP% através de sua Variável de Ambiente	
	private DirectoryInfo temp2 { get; set; } = new DirectoryInfo(Environment.GetEnvironmentVariable("TEMP"));
	
	//Pega o Diretório da Pasta PREFETCH
	private DirectoryInfo prefetch { get; set; } = new DirectoryInfo(@"C:\Windows\Prefetch\");

	//Retorna o Tamanho (KB, MB ou GB) total da Pasta TEMP
	public string totalTemp1(){		
		return analisaUnidades(getSizes(contaArquivos(temp1)));
	}
	
	//Retorna o Tamanho (KB, MB ou GB) total da Pasta %TEMP%
	public string totalTemp2(){
		return analisaUnidades(getSizes(contaArquivos(temp2)));
	}
	
	//Retorna o Tamanho (KB, MB ou GB) total da Pasta PREFETCH
	public string totalPref(){
		return analisaUnidades(getSizes(contaArquivos(prefetch)));
	}
	
	//Mostra o Tamanho das Pastas (Temp, %Temp% e Prefetch) Antes e Depois da Limpeza Acontecer
	public string mostraTamanhoTotal(){
		return    " ------------------------------------------------"   + "\n" +
				  "| Tamanho da Pasta Temp: "     + totalTemp1() + "\n" +
				  "| Tamanho da Pasta %Temp%: "   + totalTemp2() + "\n" +
				  "| Tamanho da Pasta Prefetch: " + totalPref()  + "\n" +
				  " -------------------------------------------------";
	}
	
	//Lista que armazena o(s) Tamanho(s) da(s) Pasta(s) para Analisar em qual Unidade (KB, MB ou GB se enquadram
	private List<double> getSizes(long tamanho){
		List<double> tamanhos = new List<double>();
		
		tamanhos.Add(convertByteToGB(tamanho));
		tamanhos.Add(convertByteToMB(tamanho));
		tamanhos.Add(convertByteToKB(tamanho));
		
		return tamanhos;
	}
	
	//Função Responsável por Contabilizar o Tamanho total em Bytes das Pastas
	private long contaArquivos(DirectoryInfo pasta){
		long tamanho = 0;
		
		//Conta o Tamanho Total dos Arquivos das Pastas 
		foreach (var file in pasta.GetFiles()){
			tamanho += file.Length;
		}
		
		//Conta o Tamanho Total dos Arquivos dentro do(s) Subdiretório(s) das Pastas
		foreach (var subDiretorios in pasta.GetDirectories()){
			tamanho += contaArquivos(subDiretorios);
		}
		
		return tamanho;
	}
	
	//Convert Byte pra Gigabyte
	private double convertByteToGB(long size){
		return size / 1073741824;
	}
	
	//Convert Byte pra Megabyte
	private double convertByteToMB(long size){
		return size / 1048576;
	}
	
	//Convert Byte pra Kilobyte
	private double convertByteToKB(long size){
		return size / 1024;
	}
	
	//Descobre em qual Unidade o Tamanho da(s) Pasta(s) se enquadram
	private string analisaUnidades(List<double> listaPasta){
		if(listaPasta[0] > 0){
			//Unidade com Tamanho GB
			return listaPasta[0] + "GB";
		}
		else if(listaPasta[1] > 0 ){
			//Unidade com Tamanho mb
			return listaPasta[1] + "MB";
		}
		else {
			//Unidade com Tamanho KB
			return listaPasta[2] + "KB";
		}
	}
}
