<template>
    <Icon :icon="Icons.Spinner" :isSpinning="true" :color="InteractableElementLight.backgroundColor" />
</template>

<script setup lang="ts">
import { Icons } from '../../models/icons/Icons';
import { InteractableElementLight } from '../../models/style/Styles';
import Icon from '../reusable/Icon.vue';
</script>
