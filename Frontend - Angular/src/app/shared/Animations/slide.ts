import { trigger, transition, style, animate } from '@angular/animations';

export let slide = trigger('slide',[
    transition("void => *",[
      style({transform:'translateX(35px)',opacity:0}),
      animate('0.6s')
    ])
  ])