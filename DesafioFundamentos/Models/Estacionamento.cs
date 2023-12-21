using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;


        //Padrões de Placas adicionados para evitar erros de digitação da placa do veiculo
        string placaPadrãoMercosul = @"^[A-Za-z]{3}\d[A-Za-z]\d{2}$";
        string placaPadrãoAntigo = @"^[A-Za-z]{3}\d{4}$";
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {   
            //While verifica se a Entrada esta de acordo com o Padrão
            while(true){

                // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
                // *IMPLEMENTE AQUI*
                Console.WriteLine("Digite a placa do veículo para estacionar:");
                Console.WriteLine("Modelo Antigo: AAA-0000, Modelo Novo Mercosul: AAA0A00 ");
                Console.WriteLine("\nOu entre com 0 para sair");
                string placaTempInput = Console.ReadLine();
                
             
                if (placaTempInput == "0")
                {
                    Console.WriteLine("Você saiu do cadastro!");
                    break;
                }



                if(Regex.IsMatch(placaTempInput, placaPadrãoMercosul ) || Regex.IsMatch(placaTempInput, placaPadrãoAntigo))
                {
                    veiculos.Add(placaTempInput);
                    placaTempInput = "";
                    Console.WriteLine("Veiculo cadastrado com sucesso!");
                    break;
                }
                else{

                    Console.WriteLine("A entrada não esta no formato correto, porfavor tente novamente!\nSe tiver alguma duvida siga os modelos apresentados\n");
                }
       
            }



        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTE AQUI*
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                
                while(true)
                {


                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                    string Inputhoras = Console.ReadLine();

                    if (int.TryParse(Inputhoras, out int horas))
                    {
                        Console.WriteLine($"Você digitou: {horas} horas.");
                        
                        // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                        // *IMPLEMENTE AQUI
                        decimal valorTotal = 0;     

                        valorTotal = precoInicial + (precoPorHora * horas);

                        // TODO: Remover a placa digitada da lista de veículos
                        veiculos.Remove(placa.ToUpper());
                        // *IMPLEMENTE AQUI*
                        Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Entrada inválida. Certifique-se de inserir um número inteiro.");
                    }
                }
               
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI*
                foreach(var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }

            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
