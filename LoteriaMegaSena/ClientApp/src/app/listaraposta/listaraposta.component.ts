import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-listaraposta',
  templateUrl: './listaraposta.component.html'
})
export class ListarApostaComponent {

  public apostas: Aposta[];

  constructor(http: HttpClient, @Inject('BASE_URL') _baseUrl: string) {
    var aposta = {} as Aposta;
    aposta.codigoTipoAposta = 'M';
    http.post<Aposta[]>(_baseUrl + 'api/Resultado/RetornaApostas', aposta).subscribe(result => {
      this.apostas = result;
    }, error => console.error(error));

  }
}

interface Aposta {
  id: number;
  numerosExib: string;
  data: string;
  descricaoTipoAposta: string;
  codigoTipoAposta: string;
}
