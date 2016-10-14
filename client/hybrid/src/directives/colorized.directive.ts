import { Directive, ElementRef, Renderer, AfterViewInit, Input } from '@angular/core';

@Directive({
    selector: '[colorized]'
})
export class ColorizedDirective implements AfterViewInit {
    private _defaultbound = 10;

    @Input('colorized') bound: number;

    constructor(public el: ElementRef, public renderer: Renderer) {
    }

    ngAfterViewInit() {
        // TODO: make it bullet-proof
        //debugger;
        let text = this.el.nativeElement.innerText;
        let num = text.match(/-?\d+(?:\.\d+)?/);
        if (num && num.length === 1) {
            let n2 = parseFloat(num[0]);
            if (n2 >= (this.bound || this._defaultbound)) {
                this.renderer.setElementStyle(this.el.nativeElement, 'color', 'green');
            } else {
                this.renderer.setElementStyle(this.el.nativeElement, 'color', 'red');
            }
        }
    }
}
