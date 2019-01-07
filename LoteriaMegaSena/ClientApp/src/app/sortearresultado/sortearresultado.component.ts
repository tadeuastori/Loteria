import { Component, Inject } from '@angular/core';
import { HttpClient, } from '@angular/common/http';

@Component({
  selector: 'app-sortearresultado',
  templateUrl: './sortearresultado.component.html'
})
export class SortearResultadoComponent {
  public numerosSorteados: string;
  private httpClient: HttpClient;
  private baseUrl: string;

  public ganhadores: Ganhador[];
  public ganhadoresQuina: Ganhador[];
  public ganhadoresQuadra: Ganhador[];

  sortear() {
    this.httpClient.get<NumResultado>(this.baseUrl + 'api/Resultado/SortearNumeros?tipoAposta=M').subscribe(result => {
      this.numerosSorteados = result.numeros;
      this.carregarGanhadores();
      this.carregarGanhadoresQuina();
      this.carregarGanhadoresQuadra();
    }, error => console.error(error));
  }

  constructor(http: HttpClient, @Inject('BASE_URL') _baseUrl: string) {
    this.httpClient = http;
    this.baseUrl = _baseUrl;
    this.httpClient.get<NumResultado>(this.baseUrl + 'api/Resultado/ObterNumerosSorteados?tipoAposta=M').subscribe(result => {
      this.numerosSorteados = result.numeros;
      this.carregarGanhadores();
      this.carregarGanhadoresQuina();
      this.carregarGanhadoresQuadra();
    }, error => console.error(error));
  }

  carregarGanhadores() {
    var aposta = {} as Ganhador;
    aposta.codigoTipoAposta = 'M';
    this.httpClient.post<Ganhador[]>(this.baseUrl + 'api/Resultado/CarregarGanhadores', aposta).subscribe(result => {
      this.ganhadores = result;
    }, error => console.error(error));
  }

  carregarGanhadoresQuina() {
    var aposta = {} as Ganhador;
    aposta.codigoTipoAposta = 'M';
    this.httpClient.post<Ganhador[]>(this.baseUrl + 'api/Resultado/CarregarGanhadoresQuina', aposta).subscribe(result => {
      this.ganhadoresQuina = result;
    }, error => console.error(error));
  }

  carregarGanhadoresQuadra() {
    var aposta = {} as Ganhador;
    aposta.codigoTipoAposta = 'M';
    this.httpClient.post<Ganhador[]>(this.baseUrl + 'api/Resultado/CarregarGanhadoresQuadra', aposta).subscribe(result => {
      this.ganhadoresQuadra = result;
    }, error => console.error(error));
  }
}

interface NumResultado {
  numeros: string;
}

interface Ganhador {
  id: number;
  numerosExib: string;
  data: string;
  codigoTipoAposta: string;
}
