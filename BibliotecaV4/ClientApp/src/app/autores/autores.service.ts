import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { IAutor } from './autor';

@Injectable()
export class AutoresService {


  private apiURL = this.baseUrl + "api/autores";

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  GetAutores(): Observable<IAutor[]> {
    return this.http.get<IAutor[]>(this.apiURL);
  }

  getAutor(autorId: string): Observable<IAutor> {
    return this.http.get<IAutor>(this.apiURL + '/' + autorId);

  }
  createAutor(autor: IAutor): Observable<IAutor> {
    return this.http.post<IAutor>(this.apiURL, autor);
  }

  updateAutor(autor: IAutor): Observable<IAutor> {
    return this.http.put<IAutor>(this.apiURL + "/" + autor.idAutor.toString(), autor);
  }

  deleteAutor(autorId: string): Observable<IAutor> {
    return this.http.delete<IAutor>(this.apiURL + "/" + autorId);
  }

}
