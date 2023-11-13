import { IInteractableElement } from "./IInteractableElement";
import { ColorWrapper } from './ColorWrapper';
import { darkModeColorPalette } from './ColorPalette';
import { IElement } from './IElement';

export const InteractableElementLight: IInteractableElement = {
    color:              darkModeColorPalette.drawSample(0.1),
    backgroundColor:    darkModeColorPalette.drawSample(1),
    pressColor:         darkModeColorPalette.drawSample(0.85),
    hoverColor:         darkModeColorPalette.drawSample(0.8)
}

export const ElementLight: IElement = {
    color:              darkModeColorPalette.drawSample(0.1),
    backgroundColor:    darkModeColorPalette.drawSample(0.8),
}

