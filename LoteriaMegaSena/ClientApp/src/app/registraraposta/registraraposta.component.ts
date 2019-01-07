import { Component, ViewChild, ElementRef, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './registraraposta.component.html',
  styleUrls: ['./registraraposta.component.css']
})
export class RegistrarApostaComponent {

  @ViewChild('pnlErro') pnlErro: ElementRef;
  @ViewChild('pnlJogo') pnlJogo: ElementRef;
  @ViewChild('pnlApostaCadastrada') pnlApostaCadastrada: ElementRef;

  private quantidadeNumeros;
  private maiorNumero;
  private descricao: string;
  private erro: string;
  private httpClient: HttpClient;
  private baseUrl: string;

  private numSelecao = [];
  public apostas: RegistrarAposta[];


  private marcarElemento = function (elemento: any) {

    if (elemento.classList.contains('dvopton')) {

      elemento.classList.remove('dvopton');
      elemento.classList.add('dvoptoff');

      elemento.firstElementChild.classList.remove('numopton');
      elemento.firstElementChild.classList.add('numoptoff');

      var index = this.numSelecao.indexOf(elemento.firstElementChild.innerHTML);
      if (index > -1) {
        this.numSelecao.splice(index, 1);
      }
    }
    else {

      if (this.numSelecao.length < this.quantidadeNumeros) {
        elemento.classList.add('dvopton');
        elemento.classList.remove('dvoptoff');

        elemento.firstElementChild.classList.add('numopton');
        elemento.firstElementChild.classList.remove('numoptoff');

        this.numSelecao.push(elemento.firstElementChild.innerHTML);
      }
    }
  }

  private exibirAposta = function (aposta: RegistrarAposta) {
    this.pnlApostaCadastrada.nativeElement.style.display = 'block';
    this.apostas = [];
    this.apostas.push(aposta);
  }

  constructor(http: HttpClient, @Inject('BASE_URL') _baseUrl: string) {
    this.httpClient = http;
    this.baseUrl = _baseUrl;
    http.get<ConfiguracaoApostaDTO>(_baseUrl + 'api/RegistrarAposta/BuscarConfiguracao?tipoAposta=M').subscribe(result => {
      this.pnlErro.nativeElement.style.display = result.mensagemErro == null ? 'none' : 'block';
      this.pnlJogo.nativeElement.style.display = result.mensagemErro == null ? 'block' : 'none';
      this.pnlApostaCadastrada.nativeElement.style.display = 'none';

      this.erro = result.mensagemErro;

      if (result.mensagemErro == null) {
        this.quantidadeNumeros = result.quantidadeNumeros;
        this.maiorNumero = result.maiorNumero;
        this.descricao = result.descricao;
      }
    }, error => console.error(error));
  }

  counter() {
    var arr = [];
    for (var i = 0; i < this.maiorNumero; i++) {
      arr.push(i + 1);
    }
    return arr;
  }

  marcarNumero(event: Event) {

    this.marcarElemento(event.currentTarget);
  }

  limpar() {
    this.pnlErro.nativeElement.style.display = 'none';
    this.pnlApostaCadastrada.nativeElement.style.display = 'none';
    this.numSelecao = [];

    var elems = document.querySelectorAll(".dvopton");

    for (var i = 0; i < elems.length; i++) {
      elems[i].classList.remove('dvopton');
      elems[i].classList.add('dvoptoff');
    }

    elems = document.querySelectorAll(".numopton");
    for (i = 0; i < elems.length; i++) {
      elems[i].classList.remove('numopton');
      elems[i].classList.add('numoptoff');
    }
  }

  numeroAleatorios() {
    this.limpar();
    var nums = [];

    while (nums.length < this.quantidadeNumeros) {
      var num = Math.floor((Math.random() * this.maiorNumero) + 1);

      if (!nums.includes(num)) {
        nums.push(num);
      }
    }

    var opcoes = document.querySelectorAll(".dvoptoff");

    for (var i = 0; i < opcoes.length; i++) {

      if (nums.includes(parseInt(opcoes[i].firstElementChild.innerHTML))) {
        this.marcarElemento(opcoes[i]);
      }
    }
  }

  realizarJogo() {
    this.pnlErro.nativeElement.style.display = 'none';

    if (this.numSelecao.length < this.quantidadeNumeros) {
      this.erro = 'Informe ' + this.quantidadeNumeros + ' números';
      this.pnlErro.nativeElement.style.display = 'block';
      this.pnlApostaCadastrada.nativeElement.style.display = 'none';
    }
    else {
      var aposta = {} as RegistrarAposta;
      aposta.numeros = this.numSelecao;
      aposta.codigoTipoAposta = 'M';

      this.httpClient.post<RegistrarAposta>(this.baseUrl + 'api/RegistrarAposta/RegistarAposta', aposta).subscribe(result => {

        this.erro = result.mensagemErro;

        if (result.mensagemErro == null) {
          this.exibirAposta(result);
        }
        else {
          this.pnlErro.nativeElement.style.display = 'block';
          this.pnlApostaCadastrada.nativeElement.style.display = 'none';
        }
      });
    }
  }

  surpresinha() {
    this.pnlErro.nativeElement.style.display = 'none';

    var aposta = {} as RegistrarAposta;
    aposta.codigoTipoAposta = 'M';

    this.httpClient.post<RegistrarAposta>(this.baseUrl + 'api/RegistrarAposta/Surpresinha', aposta).subscribe(result => {

      this.erro = result.mensagemErro;

      if (result.mensagemErro == null) {
        this.limpar();
        this.exibirAposta(result);
      }
      else {
        this.pnlErro.nativeElement.style.display = 'block';
      }
    });
  }

}

interface ConfiguracaoApostaDTO {
  quantidadeNumeros: number;
  maiorNumero: number;
  mensagemErro: string;
  descricao: string;
}

interface RegistrarAposta {
  numeros: Array<number>;
  codigoTipoAposta: string;
  mensagemErro: string;
  numerosExib: string;
  id: number;
  data: string;
  descricaoTipoAposta: string;
}
