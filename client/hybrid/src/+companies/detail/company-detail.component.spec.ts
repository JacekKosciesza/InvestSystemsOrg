/// <reference path="../../../node_modules/@types/jasmine/index.d.ts" />

import { ComponentFixture, TestBed, async } from '@angular/core/testing';
import { TestUtils } from '../../test';

import { CompanyDetailComponent } from './company-detail.component';
import { TranslatePipe } from 'ng2-translate/ng2-translate';
import { SocialNetworkComponent } from './social-network.component';
import { RuleOneComponent, MeaningComponent, MoatComponent, LevelFiveLeadersComponent, MarginComponent, ThreeToolsComponent, MeaningStatementComponent, ThreeCirclesComponent, FiveMoatsComponent, BigFiveComponent, EmaChartComponent, MacdChartComponent, StochasticChartComponent, BigFiveGrowthComponent, BigFiveAnnualComponent } from '../../+rule-one';

let fixture: ComponentFixture<CompanyDetailComponent> = null;
let instance: any = null;

describe('Pages: CompanyDetailComponent', () => {

  beforeEach(() => {
    TestUtils.configureIonicTestingModule([CompanyDetailComponent, TranslatePipe, SocialNetworkComponent, RuleOneComponent, MeaningComponent, MoatComponent, LevelFiveLeadersComponent, MarginComponent, ThreeToolsComponent, MeaningStatementComponent, ThreeCirclesComponent, FiveMoatsComponent, BigFiveComponent, EmaChartComponent, MacdChartComponent, StochasticChartComponent, BigFiveGrowthComponent, BigFiveAnnualComponent]);
    fixture = TestBed.createComponent(CompanyDetailComponent);
    instance = fixture.debugElement.componentInstance;
  });

  it('should create CompanyDetailComponent', async(() => {
    expect(instance).toBeTruthy();
  }));
});