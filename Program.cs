//Acessará as Pastas (Temp, %Temp% e Prefetch do Windows
var pastas = new Pastas();

//Tamanho das Pastas (Temp, %Temp% e Prefetch) Antes da Limpeza
Console.WriteLine(pastas.mostraTamanhoTotal());

//Cria e depois recebe o Processo Criado (Em Execução)
var processo = new Processo();

//Mostra se o(s) processo(s) foram finalizados com ou sem êxito
Console.WriteLine(processo.abrirProcesso());

//Tamanho das Pastas (Temp, %Temp% e Prefetch) após a Limpeza
Console.WriteLine(pastas.mostraTamanhoTotal());