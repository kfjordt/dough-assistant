import { IElement } from './IElement';
import { ColorWrapper } from './ColorWrapper';

export interface IInteractableElement extends IElement {
    pressColor: ColorWrapper,
    hoverColor: ColorWrapper
}