import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { ILibro } from './libro';

@Injectable()
export class LibrosService {

  
  private apiURL = this.baseUrl + "api/libros";

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }
  
  GetLibros(): Observable<ILibro[]> {
    return this.http.get<ILibro[]>(this.apiURL);
  }

  getLibro(libroId: string): Observable<ILibro>{
    return this.http.get<ILibro>(this.apiURL + '/' + libroId);

  }
  createLibro(libro: ILibro): Observable<ILibro> {
    return this.http.post<ILibro>(this.apiURL, libro);
  }

  updateLibro(libro: ILibro): Observable<ILibro> {
    return this.http.put<ILibro>(this.apiURL + "/" + libro.id.toString(), libro);
  }

  deleteLibro(libroId: string): Observable<ILibro> {
    return this.http.delete<ILibro>(this.apiURL + "/" + libroId);
  }

}
