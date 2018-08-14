import { Injectable } from '@angular/core';
import {Hero} from '../hero';
import {HEROES} from '../mock-heroes';
import {Observable, of} from 'rxjs';
import {MessageService} from './message.service';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';


const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class HeroService {

  private readonly _userById: string = '/heroes';
  private readonly _updateHero: string = '/updateHero';
  private readonly _addHero: string = '/addHero';
  private readonly _deleteHero: string = '/deleteHero';
  private readonly _search: string = '/search';

  private heroesUrl = 'http://localhost:38259/api/Hero'; //url to web api


  constructor(private httpService:HttpClient, private messageService:MessageService) { }

  get userById(){
    return this.heroesUrl + this._userById;
  }

  get updateHeroes()
  {
    return this.heroesUrl + this._updateHero;
  }

  get addHeroes()
  {
    return this.heroesUrl + this._addHero;
  }

  get deleteHeros()
  {
    return this.heroesUrl + this._deleteHero;
  }

  get searchHeroes()
  {
    return this.heroesUrl + this._search;
  }

  /** Log a HeroService message with the MessageService */
  private log(message: string) {
  this.messageService.add(`HeroService: ${message}`);
  }

  getHero(id: number): Observable<Hero> {
    // TODO: send the message _after_ fetching the hero
    this.messageService.add(`HeroService: fetched hero id=${id}`);
    const url = `${this.userById}/${id}`;
    return this.httpService.get<Hero>(url,httpOptions)
               .pipe(
                 tap(_ => this.log('fetched heroes')),
                 catchError(this.handleError<Hero>(`get hero id=${id}`))
               );
  }

  getHeroes (): Observable<Hero[]> {
    return this.httpService.get<Hero[]>(this.heroesUrl,httpOptions)
      .pipe(
        tap(heroes => this.log('fetched heroes')),
        catchError(this.handleError('getHeroes', []))
      );
  }

  updateHero(hero: Hero): Observable<any>{
    const url = `${this.updateHeroes}`;
    return this.httpService.put(url, hero, httpOptions).pipe(
      tap(_ => this.log(`updated hero id = ${hero.id}`)),
      catchError(this.handleError<any>('updated hero'))
    );
  }

  addHero(hero:Hero): Observable<Hero>{
    return this.httpService.post(this.addHeroes,hero,httpOptions).pipe(
      tap( (hero:Hero) => this.log(`added hero w/ id=${hero.id}`)),
      catchError(this.handleError<Hero>('add hero')) 
    );
  }

  deleteHero(hero: Hero | number):Observable<Hero>{
    const id = typeof(hero) === 'number' ? hero: hero.id;
    const url = `${this.deleteHeros}/${id}`;

    return this.httpService.delete<Hero>(url,httpOptions).pipe(
      tap(_ => this.log(`delete hero with id ${id}`)),
      catchError(this.handleError<Hero>('deleteHero'))
    );
  }

  searchHero(term: string):Observable<Hero[]>{
    if(!term.trim())
    {
      return of([]);
    }
    return this.httpService.get<Hero[]>(`${this.searchHeroes}/?name=${term}`).pipe(
        tap(_ => this.log(`found heroes mathing "${term}"`)),
        catchError(this.handleError<Hero[]>('searchHeroes',[]))
    );
  }

  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
   
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead
   
      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);
   
      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  
}
