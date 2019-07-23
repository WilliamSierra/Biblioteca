import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { ICategoria } from './categoria';

@Injectable()
export class CategoriasService {


  private apiURL = this.baseUrl + "api/categorias";

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  GetCategorias(): Observable<ICategoria[]> {
    return this.http.get<ICategoria[]>(this.apiURL);
  }

  getCategoria(categoriaId: string): Observable<ICategoria> {
    return this.http.get<ICategoria>(this.apiURL + '/' + categoriaId);

  }
  createCategoria(categoria: ICategoria): Observable<ICategoria> {
    return this.http.post<ICategoria>(this.apiURL, categoria);
  }

  updateCategoria(categoria: ICategoria): Observable<ICategoria> {
    return this.http.put<ICategoria>(this.apiURL + "/" + categoria.id.toString(), categoria);
  }

  deleteCategoria(categoriaId: string): Observable<ICategoria> {
    return this.http.delete<ICategoria>(this.apiURL + "/" + categoriaId);
  }

}
