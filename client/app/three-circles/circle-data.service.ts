import { Injectable }    from '@angular/core';
import { Headers, Http, Response } from '@angular/http';

import 'rxjs/Rx'; // get everything from Rx
import { Observable } from 'rxjs/Observable';
// import 'rxjs/add/operator/toPromise';
// import 'rxjs/add/operator/map';
// import 'rxjs/add/operator/mergeMap';
//import 'rxjs/add/operator/flatMap';
// import 'rxjs/add/operator/filter';

import { MeaningArea } from './meaning-area'
import { MeaningCircleType } from './meaning-circle-type'

@Injectable()
export class CircleDataService {

  private areasUrl = 'app/areas';  // URL to web api

  constructor(private http: Http) { }

  getAreas(type?: MeaningCircleType): Promise<MeaningArea[]> {
    return this.http.get(this.areasUrl)
               .toPromise()
               .then(response => response.json().data)
               .then(data => {                 
                 if (type) {
                  return data.filter(x => x.type === MeaningCircleType[type]);
                 }
                 return data;
                })
               .catch(this.handleErrorPromise);
  }

  suggest(term: string, type?: MeaningCircleType) : Observable<string[]> {
    return this.http.get(this.areasUrl)
            .map((response: Response) => (<MeaningArea[]> response.json().data) // get payload, so array of areas
                        .map(x => x.name) // array of names
                        .filter(x => x.toLocaleLowerCase().indexOf(term.toLocaleLowerCase()) > -1) // names that contains term (as substring)
                        
            ).catch(this.handleErrorObservable);
  }

  getArea(id: number) {
    return this.getAreas()
               .then(areas => areas.filter(area => area.id === id)[0]);
  }

  save(area: MeaningArea): Promise<MeaningArea>  {
    if (area.id) {
      return this.put(area);
    }
    return this.post(area);
  }

  delete(area: MeaningArea) {
    let headers = new Headers();
    headers.append('Content-Type', 'application/json');

    let url = `${this.areasUrl}/${area.id}`;

    return this.http
               .delete(url, headers)
               .toPromise()
               .catch(this.handleErrorPromise);
  }

  // Add new Area
  private post(area: MeaningArea): Promise<MeaningArea> {
    let headers = new Headers({
      'Content-Type': 'application/json'});

    return this.http
               .post(this.areasUrl, JSON.stringify(area), {headers: headers})
               .toPromise()
               .then(res => res.json().data)
               .catch(this.handleErrorPromise);
  }

  // Update existing Area
  private put(area: MeaningArea) {
    let headers = new Headers();
    headers.append('Content-Type', 'application/json');

    let url = `${this.areasUrl}/${area.id}`;

    return this.http
               .put(url, JSON.stringify(area), {headers: headers})
               .toPromise()
               .then(() => area)
               .catch(this.handleErrorPromise);
  }

  private handleErrorPromise(error: any) {
    console.error('An error occurred', error); // customize it
    return Promise.reject(error.message || error);
  }

   private handleErrorObservable(error: any) {
    console.error('An error occurred', error); // customize it
    return Observable.throw(error); // our opportunity to customize this error
  }
}
