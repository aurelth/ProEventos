import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Evento } from '../models/Evento';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class EventoService {
  baseUrl: string = 'https://localhost:5001/api/evento';

  constructor(private http: HttpClient) {}

  public getEventos(): Observable<Evento[]> {
    return this.http.get<Evento[]>(`${this.baseUrl}`);
  }

  public getEventosByTema(tema: string): Observable<Evento[]> {
    return this.http.get<Evento[]>(`${this.baseUrl}/${tema}/tema`);
  }

  public getEventoById(id: number): Observable<Evento> {
    return this.http.get<Evento>(`${this.baseUrl}/${id}`);
  }
}