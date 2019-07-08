import { trigger, transition, style, animate } from '@angular/animations';

export let scale = trigger('scale',[
    transition("void => *",[
      style({transform:'scale(0.7)'}),
      animate('0.4s')
    ])
  ]);