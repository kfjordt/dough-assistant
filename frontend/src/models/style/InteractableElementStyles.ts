import { IInteractableElement } from "./IInteractableElement";
import { ColorWrapper } from './ColorWrapper';
import { darkModeColorPalette } from './ColorPalette';

export const InteractableElementLight: IInteractableElement = {
    color:              darkModeColorPalette.drawSample(0.1),
    backgroundColor:    darkModeColorPalette.drawSample(1),
    pressColor:         darkModeColorPalette.drawSample(0.7),
    hoverColor:         darkModeColorPalette.drawSample(0.8)
}

