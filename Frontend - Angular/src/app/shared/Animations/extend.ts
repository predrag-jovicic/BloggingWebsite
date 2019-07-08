import { transition, style, animate, trigger } from '@angular/animations';

export let extend = trigger('extend',[
    transition("void => *",[
      style({width:0,height:0,opacity:0}),
      animate('2s ease-out')
    ]),
    transition("void => *",[
      style({opacity:0}),
      animate('2s 500ms')
    ]),
  ])