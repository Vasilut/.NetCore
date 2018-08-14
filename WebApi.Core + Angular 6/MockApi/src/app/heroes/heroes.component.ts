import { Component, OnInit } from '@angular/core';
import {Hero} from '../hero';
import {HeroService} from '../services/hero.service';

@Component({
  selector: 'app-heroes',
  templateUrl: './heroes.component.html',
  styleUrls: ['./heroes.component.css']
})
export class HeroesComponent implements OnInit {

  heroes: Hero[];

  constructor(private heroService: HeroService) {

   }

  ngOnInit() {
    this.getHeroes();
  }

  getHeroes() : void
  {
    this.heroService.getHeroes().subscribe(eroi => this.heroes = eroi);
  }

  add(heroName: string): void
  {
    heroName = heroName.trim();
    if(!heroName){
      return;
    }

    let hr : Hero = {
      id : 0,
      name : heroName
    };

    this.heroService.addHero(hr).subscribe(hero => {
      this.heroes.push(hero);
    });
  }

  delete(hero: Hero): void {
    this.heroes = this.heroes.filter(h => h!= hero);
    this.heroService.deleteHero(hero).subscribe();
  }
}
