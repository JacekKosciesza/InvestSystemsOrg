import { Injectable }    from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

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
               .catch(this.handleError);
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
               .catch(this.handleError);
  }

  // Add new Area
  private post(area: MeaningArea): Promise<MeaningArea> {
    let headers = new Headers({
      'Content-Type': 'application/json'});

    return this.http
               .post(this.areasUrl, JSON.stringify(area), {headers: headers})
               .toPromise()
               .then(res => res.json().data)
               .catch(this.handleError);
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
               .catch(this.handleError);
  }

  private handleError(error: any) {
    console.error('An error occurred', error);
    return Promise.reject(error.message || error);
  }
}
