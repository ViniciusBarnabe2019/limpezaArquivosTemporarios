using System.Diagnostics;

class Processo {
	private ProcessStartInfo processo { get; set; }
	private Process processoAberto { get; set; }
	
	//Executável do Processo
	private string executavel { get; set; } = "powershell.exe";
	
	//Arquivo.ps1 que será Executado no PowerShell
	private string arquivo { get; set; } = Path.GetFullPath("deletaTemps.ps1");
	
	//Privilégio ADM para WIndows
	private string privilegio { get; set; } = "runas";
	
	public Processo() {
		//Criar uma Classe de Processo
		this.processo = new ProcessStartInfo();
	}
	
	public string abrirProcesso(){
		//Define qual Executável (.exe) será usado no Processo
		processo.FileName = executavel;
		
		//Define o arquivo que será lido pelo executável do Processo
		processo.Arguments = arquivo;
		
		//Define o Nível de Privilégio em que o Processo será Executado
		processo.Verb = privilegio;		

		//Oculta Janela do Processo caso a mesma exista
		processo.WindowStyle = ProcessWindowStyle.Hidden;

		//Desativa Criação de Janela pro Processo
		processo.CreateNoWindow = true;

		//Executa o Processo pelo Shell Padrão (PowerShell) do SO
		processo.UseShellExecute = true;	
		
		//Pega o Processo em Execução (Aberto)
		processoAberto = Process.Start(processo);
		
		//HasExited Verifica de forma Assincrona se o Processo em Execução já fechou
		int count = 0;
		while(!processoAberto.HasExited){
			if(count == 0){
				Console.WriteLine("Apagando Arquivos....");
			}
			count++;
		}
		
		//Espera o Processo ser Finalizado antes de continuar
		processoAberto.WaitForExit();
		
		//Processo Finalizado com Êxito possui o Código 0
		if(processoAberto.ExitCode == 0){
			return "Arquivos Temporários Apagados com Sucesso!";
		}  
		else {
			//Retorna o Código de Saída do Processo Finalizado com Erro(s)
			return "Processo finalizado com o erro " + processoAberto.ExitCode;
		}
	}
}