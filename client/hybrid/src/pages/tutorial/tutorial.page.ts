import { Component, OnInit } from '@angular/core';

import { NavController } from 'ionic-angular';

import { Slide } from './slide';
import { CompanyListComponent } from '../../+companies';

@Component({
    selector: 'tutorial-page',
    templateUrl: 'tutorial.page.html'
})
export class TutorialPage implements OnInit {
    public slides: Array<Slide>;

    constructor(public navCtrl: NavController) { }

    ngOnInit() {
        this.slides = [
            {
                title: "InvestSystems",
                description: `
                    Social network & tools for non-professional investors.<br>
                    <section>
                        <h3>Features</h3><br>
                        <ul>
                            <li>list of all public companies</li>
                            <li>full Rule #1 analysis</li>
                            <li>paper trading</li>
                        </ul>
                    </section>
                `,
                image: "/assets/icon/invest-systems-org-256x256.png",
            },
            {
                title: "Inspiration",
                description: "<b>Rule #1</b> by Phil Town was an inspiration to get interested in investing and to create this tools.",
                image: "http://assets.ruleoneinvesting.com.s3.amazonaws.com/blog/pictures/best-investing-books-every-investor-should-read/rule-1-phil-town.jpg",
            }            
        ];
    }

    skip() {
        this.navCtrl.setRoot(CompanyListComponent);
    }
}